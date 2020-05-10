using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTOs.SlackAppDTOs;
using Common.Contracts;
using Common.DTOs.WorkspaceAppDTOs;

namespace Common.Services
{
    public class SlackService: IWorkspaceService
    {
        private readonly Http.Http _http = new Http.Http();
        private readonly string _baseUri = "https://slack.com/api";
        private readonly Dictionary<string, string> headers = new Dictionary<string, string>();
        private readonly string _slackAuthToken;

        public SlackService()
        {
            _slackAuthToken = AppSettings.AppSettings.SlackAuthToken;
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

        public async Task<SlackMessageDto> ChatRetrieveMessage(string channelId, string messageTs)
        {
            var MessageDto = await _http.Post<SlackMessageDto>($"{_baseUri}/conversations.history?token={_slackAuthToken}&channel={channelId}&latest={messageTs}&limit=1&inclusive=true", headers);
            return MessageDto;
        }

        public async Task<InviteDto> GetInviteStatus(string inviteUrl)
        {
            var html = await _http.GetHtml($"{inviteUrl}", headers);
            // if data contains empty team id indicates invalid
            var inviteValid = !html.Contains("data-team_id=\"\"");
            var inviteDto = new InviteDto(inviteValid);
            return inviteDto;
        }
    }
}
