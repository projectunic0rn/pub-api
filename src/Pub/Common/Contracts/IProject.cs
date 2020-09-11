using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Common.DTOs;
using Microsoft.AspNetCore.JsonPatch;

namespace Common.Contracts
{
    public interface IProject
    {
        Task<List<ProjectDto>> GetProjectsAsync(bool searchableOnly = true);
        Task<DetailedProjectDto> GetProjectAsync(Guid Id);
        Task<ProjectDto> CreateProjectAsync(ProjectDto project);
        Task<DetailedProjectDto> UpdateProjectAsync(DetailedProjectDto project);
        Task<DetailedProjectDto> PatchProjectAsync(Guid Id, JsonPatchDocument projectPatch);
        Task DeleteProjectAsync(Guid Id);
    }
}
