using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs.DiscordDTOs;
using Common.DTOs.WorkspaceAppDTOs;
using Common.Enums;

namespace Common.Services
{
    public class DiscordService: IWorkspaceService
    {
        private readonly Http.Http _http = new Http.Http();
        private readonly string _baseUri = "https://discordapp.com/api";
        private readonly Dictionary<string, string> headers = new Dictionary<string, string>();

        public DiscordService()
        {
        }

        public async Task<DTOs.WorkspaceAppDTOs.InviteDto> GetInviteStatus(string inviteUrl)
        {
            Uri uri = new Uri(inviteUrl);
            var inviteCode = uri.Segments[uri.Segments.Length - 1];
            var discordInviteDto = await _http.Get<DTOs.DiscordDTOs.InviteDto>($"{_baseUri}/invites/{inviteCode}", headers);
            Enum.TryParse(discordInviteDto.Code, out DiscordErrorCodes discordCodeType);
            var inviteDto = new DTOs.WorkspaceAppDTOs.InviteDto(true);
            if (Equals(discordCodeType, DiscordErrorCodes.UnknownInvite))
            {
                inviteDto.Valid = false;
            }

            return inviteDto;
        }
    }
}
