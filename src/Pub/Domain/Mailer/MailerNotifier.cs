using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs;
using Domain.Mailer;
using Newtonsoft.Json;
using Common.AppSettings;

namespace Domain.Notifiers.Mailer
{
    public class MailerNotifier
    {
        private readonly MailerClient _mailerClient;
        private EmailMessage _emailMessage;
        private readonly string _appName;
        private readonly string _testEmailIndicator;
        public MailerNotifier()
        {
            // Initializing 2 instances of EmailMessage in order to
            // deserialize FeedbackRecipients and MailerFromAddress. 
            // Deserializing each onto same instance overwrites value of 
            // the initial deserialization
            _testEmailIndicator = AppSettings.Env == "Staging" || AppSettings.Env == "Development" ? "[TEST EMAIL] " : "";
            _emailMessage = new EmailMessage();
            _appName = AppSettings.ApiName;
            EmailMessage emailMessage = new EmailMessage();
            _mailerClient = MailerClient.MailerClientInstance;
            _emailMessage = JsonConvert.DeserializeObject<EmailMessage>(AppSettings.FeedbackRecipients);
            emailMessage = JsonConvert.DeserializeObject<EmailMessage>(AppSettings.MailerFromAddress);
            _emailMessage.FromAddresses = emailMessage.FromAddresses;

        }
        public async Task<NotificationDto> SendNotificationAsync(NotificationDto notification)
        {
            _emailMessage.Content = notification.Content;
            _emailMessage.Subject = $"{_testEmailIndicator}{_appName}";
            await _mailerClient.SendMailAsync(_emailMessage);
            return notification;
        }
    }

    public class EmailAddress
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAddresses = new List<EmailAddress>();
            FromAddresses = new List<EmailAddress>();
        }

        public List<EmailAddress> ToAddresses { get; set; }
        public List<EmailAddress> FromAddresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}