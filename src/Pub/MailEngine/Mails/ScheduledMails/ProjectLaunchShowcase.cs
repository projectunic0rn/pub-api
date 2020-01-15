using System;
using System.Threading;
using System.Threading.Tasks;
using MailEngine.Utility;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MailEngine.Config;
using Common.DTOs.MailDTOs;
using Common.Contracts;
using Common.AppSettings;
using System.Collections.Generic;
using MailEngine.DTOs;
using Mailer.Services;
using Infrastructure.Persistence.Entities;
using System.Linq;

namespace MailEngine.Mails.ScheduledMails
{
    public class ProjectLaunchShowcase : BackgroundService
    {
        private readonly ILogger<ProjectLaunchShowcase> _logger;
        private MailConfigDto _mailConfigDto;
        private readonly MailConfig _mailConfig;
        private readonly string _mailName = "ProjectLaunchShowcase";
        private readonly string _testEmailIndicator;
        private readonly SendGridService _sendGridService;
        private readonly IStorage<UserEntity> _userStorage;
        private EmailAddress _fromAddress;
        private readonly IMessageQueue _messageQueue;

        public ProjectLaunchShowcase(ILogger<ProjectLaunchShowcase> logger, IMailConfigStorage mailConfigStorage, IMessageQueue messageQueue)
        {
            _logger = logger;
            _mailConfig = new MailConfig(mailConfigStorage);
            _testEmailIndicator = AppSettings.Env == "Staging" || AppSettings.Env == "Development" ? "[TEST EMAIL] " : "";
            _sendGridService = new SendGridService();
            _userStorage = new UserEntity();
            _fromAddress = new EmailAddress("Team from Project Unicorn", "admin@projectunicorn.dev");
            _messageQueue = messageQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _mailConfigDto = await _mailConfig.GetConfig(_mailName);
            _logger.LogDebug($"Starting {_mailConfigDto.Name} mail process...");
            cancellationToken.Register(() => _logger.LogDebug($"{_mailConfigDto.Name} mail background service is stopping."));

            while (!cancellationToken.IsCancellationRequested)
            {
                if (BackgroundTask.ShouldStart(_mailConfigDto.NextSend))
                {
                    _mailConfigDto = await _mailConfig.GetConfig(_mailName);
                    _logger.LogInformation($"Preparing {_mailConfigDto.Name} mail.");
                    List<EmailMessage> emailMessages = await PrepareMail();
                    await _messageQueue.SendMessagesAsync<EmailMessage>(emailMessages);
                    await _mailConfig.UpdateConfigNextSend(_mailName);
                }

                await Task.Delay(1000, cancellationToken);
            }
        }

        private async Task<List<EmailMessage>> PrepareMail()
        {
            List<EmailMessage> emailMessages = new List<EmailMessage>();
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(_mailConfigDto.TemplateId);
            // Get recepients and projects
            List<UserEntity> users = await _userStorage.FindAsync();

            if (users.Count() == 0)
            {
                return emailMessages;
            }

            foreach (UserEntity user in users)
            {
                EmailMessage message = BuildLaunchShowcaseMessage(user, template);
                emailMessages.Add(message);
            }

            return emailMessages;
        }

        private EmailMessage BuildLaunchShowcaseMessage(UserEntity user, SendGridTemplateDto template)
        {
            EmailMessage message = new EmailMessage();
            EmailAddress toAddress = new EmailAddress("", user.Email);
            EmailAddress fromAddress = _fromAddress;
            MailEngine.DTOs.Version templateV1 = template.Versions.First();
            message.ToAddresses.Add(toAddress);
            message.FromAddresses.Add(fromAddress);
            message.Subject = $"{templateV1.Subject} {_testEmailIndicator}";
            string htmlContent = templateV1.HtmlContent;
            string plainTextContent = templateV1.PlainContent;
            message.MailContent.Add("text/html", htmlContent);
            message.MailContent.Add("text/plain", plainTextContent);
            return message;
        }
    }
}