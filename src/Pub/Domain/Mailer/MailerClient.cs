using System.Linq;
using Common.Contracts;
using Domain.Notifiers.Mailer;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Common.AppSettings;
using System.Threading.Tasks;

namespace Domain.Mailer
{
    public class MailerClient
    {
        private static MailerClient _instance;
        private readonly IEmailConfiguration _emailConfiguration;
        private MailerClient()
        {
            _emailConfiguration = AppSettings.EmailConfiguration;
        }

        public static MailerClient MailerClientInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MailerClient();
                }
                return _instance;
            }
        }

        public async Task SendMailAsync(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));

            message.Subject = emailMessage.Subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailMessage.Content
            };

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort);
                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                await emailClient.SendAsync(message);
                emailClient.Disconnect(true);
            }

        }
    }
} 