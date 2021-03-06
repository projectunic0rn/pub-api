using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.AppSettings;
using Common.DTOs.SlackAppDTOs;

namespace CommunicationAppDomain.Services
{
    public class SlackService
    {
        private readonly Http _http = new Http();
        private readonly string _baseUri = "https://slack.com/api";
        private readonly Dictionary<string, string> headers;
        private readonly string _slackAuthToken;

        public SlackService()
        {
            _slackAuthToken = AppSettings.SlackAuthToken;
            headers = new Dictionary<string, string>() { { "Authorization", $"Bearer {_slackAuthToken}" } };
        }

        public async Task<SlackUserInfoDto> GetSlackUserInfo(string slackId)
        {
            var slackUserInfoDto = await _http.Get<SlackUserInfoDto>($"{_baseUri}/users.info?token={_slackAuthToken}&user={slackId}", headers);
            return slackUserInfoDto;
        }

        public async Task<SlackChatMessageDto> ChatPostMessage(string channelId, string text, bool asUser = false, bool unfurlLinks = true)
        {
            var chatMessageDto = await _http.Post<SlackChatMessageDto>($"{_baseUri}/chat.postMessage", headers, new { channel=channelId, text=text, as_user = asUser, unfurl_links = unfurlLinks });
            return chatMessageDto;
        }

        public async Task<SlackMessageDto> ChatRetrieveMessage(string channelId, string messageTs)
        {
            var MessageDto = await _http.Post<SlackMessageDto>($"{_baseUri}/conversations.history?token={_slackAuthToken}&channel={channelId}&latest={messageTs}&limit=1&inclusive=true", headers);
            return MessageDto;
        }

        public async Task RespondViaResponsUrl(string responseUrl, SlackCommandResponseDto slackResponse)
        {
            await _http.Post($"{responseUrl}", headers, slackResponse);
            return;
        }
    }
}
