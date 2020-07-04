using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Common.DTOs;
using Common.DTOs.MailDTOs;
using Infrastructure.Persistence.TableStorage;
using MailEngine.Config;
using MailEngine.DTOs;
using MailEngine.Persistence.Entities;
using MailEngine.Utility;
using Mailer.Services;
using Microsoft.Extensions.Logging;
using Common.Services;

namespace MailEngine.Mails.ScheduledMails
{
    public class TransactionalMailNotifier : INotifier
    {
        private readonly ILogger<TransactionalMailNotifier> _logger;
        private readonly IMessageQueue _messageQueue;
        private readonly TransactionalMailHelper _transactionalMailHelper;
        private readonly MailValidation _mailValidation;

        public TransactionalMailNotifier(ILogger<TransactionalMailNotifier> logger, IMessageQueue messageQueue, IMailConfigStorage mailConfigStorage, Settings settings, WorkspaceAppService workspaceAppService)
        {
            _logger = logger;
            _messageQueue = messageQueue;
            _transactionalMailHelper = new TransactionalMailHelper(new SendGridService(), mailConfigStorage, workspaceAppService);
            _mailValidation = new MailValidation(new Storage<SendTrackingEntity>(settings.TableStorageConnectionString, settings.MailTrackingTableName));
        }

        public async Task SendFeedbackNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending feedback notification...");
            EmailMessage emailMessage = await _transactionalMailHelper.PrepareFeedbackMail(notification);
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }

        public async Task SendWelcomeNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending welcome notification...");
            EmailMessage emailMessage = await _transactionalMailHelper.PrepareWelcomeMail(notification);
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }

        public async Task SendInvalidWorkspaceInviteNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending invalid workspace notification notification...");
            ProjectDto project = notification.NotificationObject as ProjectDto;
            EmailMessage emailMessage = await _transactionalMailHelper.PrepareInvalidWorkspaceInviteMail(notification);
            if (await _mailValidation.IsDuplicateSend($"InvalidWorkspaceInviteMessage-{project.Id.ToString()}", notification.NotificantId.ToString()))
            {
                return;
            }
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }

        public async Task SendYouJoinedProjectNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending you joined project notification...");
            EmailMessage emailMessage = await _transactionalMailHelper.PrepareYouJoinedProjectMail(notification);
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }

        public async Task SendPasswordResetNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending password reset notification...");
            EmailMessage emailMessage = await _transactionalMailHelper.PreparePasswordResetMail(notification);
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }

        public async Task SendProjectPostedNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending project posted notification...");
            ProjectDto project = notification.NotificationObject as ProjectDto;
            EmailMessage emailMessage = await _transactionalMailHelper.PrepareProjectPostedMail(notification, project);
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }
    }
}