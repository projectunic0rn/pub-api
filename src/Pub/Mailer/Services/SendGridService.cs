using System.Collections.Generic;
using System.Threading.Tasks;
using Mailer.DTOs;

namespace Mailer.Services
{
    public class SendGridService
    {
        private readonly Http _http;
        private readonly string _baseUri = "https://api.sendgrid.com/v3";
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>();
        public SendGridService()
        {
            _http = new Http();
            _headers.Add("Authorization", $"Bearer {AppSettings.SendGridApiKey}");
        }
        public async Task SendMailAsync(SendGridMailMessage emailMessage)
        {
            await _http.Post($"{_baseUri}/mail/send", _headers, emailMessage);
            return;
        }
    }
}