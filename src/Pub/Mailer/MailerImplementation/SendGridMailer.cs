using Mailer.Contracts;
using Mailer.DTOs;
using System.Threading.Tasks;
using System.Linq;
using Mailer.Services;

namespace Mailer.MailerImplementation
{
    public class SendGridMailer : IMailer
    {
        private readonly SendGridService _sendGridService;
        public SendGridMailer()
        {
            _sendGridService = new SendGridService();
        }

        public async Task SendMailAsync(EmailMessage emailMessage)
        {
            SendGridMailMessage sendGridMailMessage = new SendGridMailMessage()
            {
                From = new From()
                {
                    Email = emailMessage.FromAddresses.First().Address,
                    Name = emailMessage.FromAddresses.First().Name,
                },
                ReplyTo = new From()
                {
                    Email = emailMessage.FromAddresses.First().Address,
                    Name = emailMessage.FromAddresses.First().Name,
                },
                Personalizations = new Personalization[1] {
                    new Personalization() {
                        To = new From[1] { new From() {Email = emailMessage.ToAddresses.First().Address,  Name = emailMessage.ToAddresses.First().Name }},
                        Subject = emailMessage.Subject
                }}, 
                Content = new Content[2] {
                    new Content() {
                        Type = emailMessage.Content.First().Type,
                        Value = emailMessage.Content.First().Value
                    }, 
                    new Content() {
                        Type = emailMessage.Content.Last().Type,
                        Value = emailMessage.Content.Last().Value
                    }
                }
            };

            await _sendGridService.SendMailAsync(sendGridMailMessage);
            return;
        }
    }
}