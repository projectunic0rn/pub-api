using System;
using System.Threading.Tasks;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IProjectUser
    {
        Task<ProjectUserDto> CreateProjectUserAsync(ProjectUserDto projectUser);
        Task DeleteProjectUserAsync(Guid id);
    }
}
