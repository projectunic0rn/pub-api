using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Contracts;
using Common.DTOs;
using Domain.MappingConfig;
using Infrastructure.Persistence.Entities;

namespace Domain.Models
{
    public class ProjectUser: IProjectUser
    {
        private readonly IMapper _mapper;

        private readonly IStorage<ProjectUserEntity> _projectUserStorage;
        public ProjectUser()
        {
            _projectUserStorage = new ProjectUserEntity();

            _mapper = new InitializeMapper().GetMapper;

        }

        public async Task<ProjectUserDto> CreateProjectUserAsync(ProjectUserDto projectUser)
        {
            ProjectUserEntity projectUserEntity = _mapper.Map<ProjectUserEntity>(projectUser);
            var createdProjectUser = await _projectUserStorage.CreateAsync(projectUserEntity);
            return _mapper.Map<ProjectUserDto>(createdProjectUser);
        }
        
        public async Task DeleteProjectUserAsync(Guid id)
        {
            await _projectUserStorage.DeleteAsync(id);
            return;
        }
    }
}
