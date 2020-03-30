using System;
using System.Threading.Tasks;
using Common.DTOs.WorkspaceAppDTOs;

namespace Common.Contracts
{
    public interface IWorkspaceService
    {
        Task<InviteDto> GetInviteStatus(string invite);
    }
}
