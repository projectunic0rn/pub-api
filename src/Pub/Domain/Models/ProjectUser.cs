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
    public class ProjectUser: IProjectUser
    {
        private readonly IMapper _mapper;

        private readonly IStorage<ProjectUserEntity> _projectUserStorage;
        private readonly IStorage<UserEntity> _userStorage;
        
        public ProjectUser()
        {
            _projectUserStorage = new ProjectUserEntity();
            _userStorage = new UserEntity();

            _mapper = new InitializeMapper().GetMapper;

        }

        public async Task<ProjectUserDto> CreateProjectUserAsync(ProjectUserDto projectUser)
        {
            UserEntity userEntity = await _userStorage.FindAsync(u => u.Id == projectUser.UserId);
            if(userEntity == null)
            {
                throw new ProjectUserException(ExceptionMessage.InvalidUserId);
            }

            ProjectUserEntity projectUserEntity = _mapper.Map<ProjectUserEntity>(projectUser);
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
