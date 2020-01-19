using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Contracts;
using Common.DTOs;
using Domain.Exceptions;
using Domain.MappingConfig;
using Infrastructure.Persistence.Entities;

namespace Domain.Models
{
    public class ProjectUser : IProjectUser
    {
        private readonly IMapper _mapper;

        private readonly IStorage<ProjectUserEntity> _projectUserStorage;
        private readonly IStorage<UserEntity> _userStorage;
        private readonly IStorage<ProjectEntity> _projectStorage;

        public ProjectUser()
        {
            _projectUserStorage = new ProjectUserEntity();
            _userStorage = new UserEntity();
            _projectStorage = new ProjectEntity();
            _mapper = new InitializeMapper().GetMapper;

        }

        public async Task<ProjectUserDto> CreateProjectUserAsync(ProjectUserDto projectUser)
        {
            UserEntity userEntity = await _userStorage.FindAsync(u => u.Id == projectUser.UserId);
            if (userEntity == null)
            {
                throw new ProjectUserException(ExceptionMessage.InvalidUserId);
            }

            ProjectEntity project = await _projectStorage.FindAsync(p => p.Id == projectUser.ProjectId);
            ProjectUserEntity projectUserEntity = _mapper.Map<ProjectUserEntity>(projectUser);
            
            // if there are currently no members on the project,
            // default first member to project owner
            projectUserEntity.IsOwner = project.ProjectUsers.Count == 0;
            
            var createdProjectUser = await _projectUserStorage.CreateAsync(projectUserEntity);
            var createdProjectUserDto = _mapper.Map<ProjectUserDto>(createdProjectUser);
            createdProjectUserDto.Username = userEntity.Username;
            return createdProjectUserDto;
        }

        public async Task DeleteProjectUserAsync(Guid id)
        {
            await _projectUserStorage.DeleteAsync(id);
            return;
        }
    }
}
