using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IUser
    {
        Task<UserDto> GetUserAsync(Guid id);
        Task<List<RecentDevDto>> GetRecentDevsAsync();
        Task<UserDto> UpdateUserAsync(UserDto user);
    }
}
