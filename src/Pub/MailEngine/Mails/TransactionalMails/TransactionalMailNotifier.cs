using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs;
using Common.DTOs.MailDTOs;
using MailEngine.Config;
using MailEngine.DTOs;
using Mailer.Services;
using Microsoft.Extensions.Logging;

namespace MailEngine.Mails.ScheduledMails
{
    public class TransactionalMailNotifier : INotifier
    {
        private readonly ILogger<TransactionalMailNotifier> _logger;
        private readonly IMessageQueue _messageQueue;
        private readonly TransactionalMailHelper _transactionalMailHelper;

        public TransactionalMailNotifier(ILogger<TransactionalMailNotifier> logger, IMessageQueue messageQueue, IMailConfigStorage mailConfigStorage)
        {
            _logger = logger;
            _messageQueue = messageQueue;
            _transactionalMailHelper = new TransactionalMailHelper(new SendGridService(), mailConfigStorage);
        }

        public async Task SendFeedbackNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending feedback mail...");
            EmailMessage emailMessage = await _transactionalMailHelper.PrepareFeedbackMail(notification);
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }

        public async Task SendWelcomeNotificationAsync(NotificationDto notification)
        {
            _logger.LogInformation($"Sending welcome mail...");
            EmailMessage emailMessage = await _transactionalMailHelper.PrepareWelcomeMail(notification);
            await _messageQueue.SendMessageAsync(emailMessage);
            return;
        }
    }
}