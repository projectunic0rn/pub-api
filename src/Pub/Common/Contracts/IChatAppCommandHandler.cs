using System;
using System.Threading.Tasks;
using Common.DTOs.SlackAppDTOs;

namespace Common.Contracts
{
    public interface IChatAppCommandHandler
    {
        Task<SlackCommandResponseDto> ProcessCommand(SlackCommandDto slackCommandDto);
    }
}
