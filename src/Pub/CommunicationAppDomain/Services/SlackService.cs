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
        private readonly Dictionary<string, string> headers = new Dictionary<string, string>();
        private readonly string _slackAuthToken;

        public SlackService()
        {
            _slackAuthToken = AppSettings.SlackAuthToken;
        }

        public async Task<SlackUserInfoDto> GetSlackUserInfo(string slackId)
        {
            var slackUserInfoDto = await _http.Get<SlackUserInfoDto>($"{_baseUri}/users.info?token={_slackAuthToken}&user={slackId}", headers);
            return slackUserInfoDto;
        }

        public async Task<SlackChatMessageDto> ChatPostMessage(string channelId, string text)
        {
            var chatMessageDto = await _http.Post<SlackChatMessageDto>($"{_baseUri}/chat.postMessage?token={_slackAuthToken}&channel={channelId}&text={text}", headers);
            return chatMessageDto;
        }
    }
}
