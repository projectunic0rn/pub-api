using System.Linq;
using Mailer.Contracts;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;
using Mailer.DTOs;

namespace Mailer.MailerImplementation
{
    // MailerClient is an implementation of IMailer
    // that uses MailKit to send email by providing
    // login credentials to an SMTP server. 
    // MailerClient is currently unused in favor of 
    // the SendGrid implementation
    public class SmtpMailer: IMailer
    {
        private static SmtpMailer _instance;
        private readonly IEmailConfiguration _emailConfiguration;

        public SmtpMailer()
        {
            _emailConfiguration = AppSettings.EmailConfiguration;
        }

        public static SmtpMailer MailerClientInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SmtpMailer();
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
                Text = emailMessage.Content.First().Value
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