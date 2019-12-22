using System;
using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IUser
    {
        Task<UserDto> GetUserAsync(Guid id);
        Task<UserDto> UpdateUserAsync(UserDto user);
    }
}
