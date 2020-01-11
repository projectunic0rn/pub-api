using System;
using System.Linq;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Common.DTOs;
using Common.DTOs.MailDTOs;
using Infrastructure.Persistence.Entities;
using MailEngine.Config;
using MailEngine.DTOs;
using Mailer.Services;
using Newtonsoft.Json;

namespace MailEngine.Mails.ScheduledMails
{
    public class TransactionalMailHelper
    {
        private readonly SendGridService _sendGridService;
        private readonly MailConfig _mailConfig;
        private EmailAddress _fromAddress;
        private readonly IStorage<UserEntity> _userStorage;
        private readonly string _testEmailIndicator;

        public TransactionalMailHelper(SendGridService sendGridService, IMailConfigStorage mailConfigStorage)
        {
            _fromAddress = new EmailAddress("Team from Project Unicorn", "admin@projectunicorn.dev");
            _testEmailIndicator = AppSettings.Env == "Staging" || AppSettings.Env == "Development" ? "[TEST EMAIL] " : "";
            _sendGridService = sendGridService;
            _mailConfig = new MailConfig(mailConfigStorage);
            _userStorage = new UserEntity();
        }

        public async Task<EmailMessage> PrepareFeedbackMail(NotificationDto notification)
        {
            string feedbackContent = notification.Content;
            EmailMessage emailMessage = new EmailMessage();
            string mailName = "FeedbackMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            MailEngine.DTOs.Version templateV1 = template.Versions.First();
            emailMessage = JsonConvert.DeserializeObject<EmailMessage>(AppSettings.FeedbackRecipients);

            EmailAddress fromAddress = _fromAddress;
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.Subject = $"{templateV1.Subject} {_testEmailIndicator}";
            string htmlContent = templateV1.HtmlContent.Replace("{{feedbackMessage}}", feedbackContent);
            string plainTextContent = templateV1.PlainContent.Replace("{{feedbackMessage}}", feedbackContent);
            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);

            return emailMessage;
        }

        public async Task<EmailMessage> PrepareWelcomeMail(NotificationDto notification)
        {
            string notifierEmail = (await _userStorage.FindAsync(u => u.Id == notification.NotifierId)).Email;
            EmailMessage emailMessage = new EmailMessage();
            string mailName = "WelcomeMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            MailEngine.DTOs.Version templateV1 = template.Versions.First();

            EmailAddress fromAddress = _fromAddress;
            EmailAddress toAddress = new EmailAddress("", notifierEmail);
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.ToAddresses.Add(toAddress);
            emailMessage.Subject = $"{templateV1.Subject} {_testEmailIndicator}";
            string htmlContent = templateV1.HtmlContent.Replace("{{currentYear}}", DateTime.Now.Year.ToString());
            string plainTextContent = templateV1.PlainContent.Replace("{{currentYear}}", DateTime.Now.Year.ToString());
            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);

            return emailMessage;
        }
    }
}