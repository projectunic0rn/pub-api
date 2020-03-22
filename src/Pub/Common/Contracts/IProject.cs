using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.DTOs;

namespace Common.Contracts
{
    public interface IProject
    {
        Task<List<ProjectDto>> GetProjectsAsync();
        Task<ProjectDto> GetProjectAsync(Guid id);
        Task<ProjectDto> CreateProjectAsync(ProjectDto project);
        Task<ProjectDto> UpdateProjectAsync(ProjectDto project);
        Task DeleteProjectAsync(Guid id);
    }
}
