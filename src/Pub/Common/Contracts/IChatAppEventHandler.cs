using System;
using System.Threading.Tasks;
using Common.DTOs.SlackAppDTOs;

namespace Common.Contracts
{
    public interface IChatAppEventHandler
    {
        Task ProcessEvent(SlackEventDto slackEventDto);
    }
}
