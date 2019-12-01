using Microsoft.AspNetCore.Http;
using Common.AppSettings;
using System.Threading.Tasks;
using System.Web;
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace SlackApp.Helpers
{
    public class SlackRequestValidator
    {
        private readonly string _requestHeaderTimeStamp = "X-Slack-Request-Timestamp";
        private readonly string _requestHeaderSignature = "X-Slack-Signature";
        private readonly string _versionNumber = "v0";
        private readonly string _slackSigningSecret = AppSettings.SlackSigningSecret;

        public async Task<bool> IsValid(HttpRequest request)
        {
            string body = string.Empty;
            if (request.HasFormContentType)
            {
                foreach (var key in request.Form.Keys)
                {
                    var urlEncodedString = HttpUtility.UrlEncode(request.Form[key]);
                    var urlEncodedStringUpper = Regex.Replace(urlEncodedString, "(%[0-9a-f][0-9a-f])", c => c.Value.ToUpper());
                    body += $"{key}={urlEncodedStringUpper}&";
                }
                var lastIndex = body.LastIndexOf("&");
                body = body.Remove(lastIndex, 1);
            }
            else
            {
                request.Body.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(request.Body);
                body = await reader.ReadToEndAsync();
            }

            var requestTimestamp = request.Headers[_requestHeaderTimeStamp].ToString();
            var slackSignature = request.Headers[_requestHeaderSignature].ToString();
            var signatureBaseString = $"{_versionNumber}:{requestTimestamp}:{body}";

            var computedSignature = ComputeSha256Hash(_slackSigningSecret, signatureBaseString);

            return slackSignature == computedSignature;
        }

        private string ComputeSha256Hash(string slackSigningSecret, string baseString)
        {
            var encoding = new UTF8Encoding();
            byte[] textBytes = encoding.GetBytes(baseString);
            byte[] keyBytes = encoding.GetBytes(slackSigningSecret);
            byte[] hashBytes;

            using (HMACSHA256 hash = new HMACSHA256(keyBytes))
                hashBytes = hash.ComputeHash(textBytes);

            string hashString = $"v0={BitConverter.ToString(hashBytes).Replace("-", "").ToLower()}";
            return hashString;
        }
    }
}