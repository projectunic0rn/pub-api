using System.Collections.Generic;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.Http;
using MailEngine.DTOs;

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
            _headers.Add("Authorization", $"Bearer {AppSettings.SendGridTemplatesApiKey}");
        }

        public async Task<SendGridTemplateDto> GetMailTemplate(string templateId) {
            SendGridTemplateDto template = await _http.Get<SendGridTemplateDto>($"{_baseUri}/templates/{templateId}", _headers);
            return template;
        }
    }
}