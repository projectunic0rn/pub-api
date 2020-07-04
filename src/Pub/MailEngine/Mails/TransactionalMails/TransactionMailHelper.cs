using System;
using System.Linq;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Contracts;
using Common.DTOs;
using Common.DTOs.MailDTOs;
using Common.Services;
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
        private readonly WorkspaceAppService _workspaceAppService;

        public TransactionalMailHelper(SendGridService sendGridService, IMailConfigStorage mailConfigStorage, WorkspaceAppService workspaceAppService)
        {
            _fromAddress = new EmailAddress("Team at Project Unicorn", "team@projectunicorn.dev");
            _testEmailIndicator = AppSettings.Env == "Staging" || AppSettings.Env == "Development" ? "[TEST EMAIL] " : "";
            _sendGridService = sendGridService;
            _mailConfig = new MailConfig(mailConfigStorage);
            _userStorage = new UserEntity();
            _workspaceAppService = workspaceAppService;
        }

        public async Task<EmailMessage> PrepareFeedbackMail(NotificationDto notification)
        {
            string feedbackContent = notification.Content;
            EmailMessage emailMessage = new EmailMessage();
            string mailName = "FeedbackMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            DTOs.Version activeTemplate = template.Versions.FirstOrDefault(v => v.Active == 1);
            emailMessage = JsonConvert.DeserializeObject<EmailMessage>(AppSettings.FeedbackRecipients);

            EmailAddress fromAddress = _fromAddress;
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.Subject = $"{activeTemplate.Subject} {_testEmailIndicator}";
            string htmlContent = activeTemplate.HtmlContent.Replace("{{feedbackMessage}}", feedbackContent);
            string plainTextContent = activeTemplate.PlainContent.Replace("{{feedbackMessage}}", feedbackContent);
            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);

            return emailMessage;
        }

        public async Task<EmailMessage> PrepareWelcomeMail(NotificationDto notification)
        {
            string notificantEmail = (await _userStorage.FindAsync(u => u.Id == notification.NotificantId)).Email;
            EmailMessage emailMessage = new EmailMessage();
            string mailName = "WelcomeMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            DTOs.Version activeTemplate = template.Versions.FirstOrDefault(v => v.Active == 1);

            EmailAddress fromAddress = _fromAddress;
            EmailAddress toAddress = new EmailAddress("", notificantEmail);
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.ToAddresses.Add(toAddress);
            emailMessage.Subject = $"{activeTemplate.Subject} {_testEmailIndicator}";
            string htmlContent = activeTemplate.HtmlContent.Replace("{{currentYear}}", DateTime.Now.Year.ToString());
            string plainTextContent = activeTemplate.PlainContent.Replace("{{currentYear}}", DateTime.Now.Year.ToString());
            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);

            return emailMessage;
        }

        public async Task<EmailMessage> PrepareInvalidWorkspaceInviteMail(NotificationDto notification)
        {
            string notificantEmail = (await _userStorage.FindAsync(u => u.Id == notification.NotificantId)).Email;
            EmailMessage emailMessage = new EmailMessage();
            string mailName = "InvalidWorkspaceInviteMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            DTOs.Version activeTemplate = template.Versions.FirstOrDefault(v => v.Active == 1);

            EmailAddress fromAddress = _fromAddress;
            EmailAddress toAddress = new EmailAddress("", notificantEmail);
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.ToAddresses.Add(toAddress);
            emailMessage.Subject = $"{activeTemplate.Subject} {_testEmailIndicator}";

            ProjectDto project = notification.NotificationObject as ProjectDto;
            string htmlContent = activeTemplate.HtmlContent
                .Replace("{{projectName}}", project.Name)
                .Replace("{{workspaceName}}", project.CommunicationPlatform);
            string plainTextContent = activeTemplate.PlainContent
                .Replace("{{projectName}}", project.Name)
                .Replace("{{workspaceName}}", project.CommunicationPlatform);
            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);


            return emailMessage;
        }

        public async Task<EmailMessage> PrepareYouJoinedProjectMail(NotificationDto notification)
        {
            string notificantEmail = (await _userStorage.FindAsync(u => u.Id == notification.NotificantId)).Email;
            EmailMessage emailMessage = new EmailMessage();
            string mailName = "YouJoinedProjectMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            DTOs.Version activeTemplate = template.Versions.FirstOrDefault(v => v.Active == 1);

            EmailAddress fromAddress = _fromAddress;
            EmailAddress toAddress = new EmailAddress("", notificantEmail);
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.ToAddresses.Add(toAddress);
            emailMessage.Subject = $"{activeTemplate.Subject} {_testEmailIndicator}";

            ProjectDto project = notification.NotificationObject as ProjectDto;
            string htmlContent = activeTemplate.HtmlContent
                .Replace("{{projectName}}", project.Name)
                .Replace("{{workspaceName}}", project.CommunicationPlatform)
                .Replace("{{inviteUrl}}", project.CommunicationPlatformUrl);
            string plainTextContent = activeTemplate.PlainContent
                .Replace("{{projectName}}", project.Name)
                .Replace("{{workspaceName}}", project.CommunicationPlatform)
                .Replace("{{inviteUrl}}", project.CommunicationPlatformUrl);
            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);

            return emailMessage;
        }

        public async Task<EmailMessage> PreparePasswordResetMail(NotificationDto notification)
        {
            UserEntity user = await _userStorage.FindAsync(u => u.Id == notification.NotificantId);
            string notificantEmail = user.Email;
            string resetToken = user.ResetPasswordToken;

            EmailMessage emailMessage = new EmailMessage();
            string mailName = "PasswordResetRequestMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            DTOs.Version activeTemplate = template.Versions.FirstOrDefault(v => v.Active == 1);

            EmailAddress fromAddress = _fromAddress;
            EmailAddress toAddress = new EmailAddress("", notificantEmail);
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.ToAddresses.Add(toAddress);
            emailMessage.Subject = $"{activeTemplate.Subject} {_testEmailIndicator}";

            string htmlContent = activeTemplate.HtmlContent.Replace("{{passwordResetToken}}", Uri.EscapeDataString(resetToken));
            string plainTextContent = activeTemplate.PlainContent.Replace("{{passwordResetToken}}", Uri.EscapeDataString(resetToken));
            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);

            return emailMessage;
        }

        public async Task<EmailMessage> PrepareProjectPostedMail(NotificationDto notification, ProjectDto project)
        {
            UserEntity user = await _userStorage.FindAsync(u => u.Id == notification.NotificantId);
            string notificantEmail = user.Email;

            EmailMessage emailMessage = new EmailMessage();
            string mailName = "ProjectPostedMessage";
            MailConfigDto mailConfigDto = await _mailConfig.GetConfig(mailName);
            SendGridTemplateDto template = await _sendGridService.GetMailTemplate(mailConfigDto.TemplateId);
            DTOs.Version activeTemplate = template.Versions.FirstOrDefault(v => v.Active == 1);

            // Get workspace install url
            string workspaceType = project.CommunicationPlatform;
            string installUrl = await _workspaceAppService.GetInstallUrl(workspaceType);

            EmailAddress fromAddress = _fromAddress;
            EmailAddress toAddress = new EmailAddress("", notificantEmail);
            emailMessage.FromAddresses.Add(fromAddress);
            emailMessage.ToAddresses.Add(toAddress);
            emailMessage.Subject = $"{activeTemplate.Subject} {_testEmailIndicator}";

            string htmlContent = activeTemplate.HtmlContent
                .Replace("{{workspaceType}}", workspaceType)
                .Replace("{{workspaceAppInstallUrl}}", installUrl);
            string plainTextContent = activeTemplate.PlainContent
                .Replace("{{workspaceType}}", workspaceType)
                .Replace("{{workspaceAppInstallUrl}}", installUrl);

            emailMessage.MailContent.Add("text/html", htmlContent);
            emailMessage.MailContent.Add("text/plain", plainTextContent);

            return emailMessage;
        }
    }
}