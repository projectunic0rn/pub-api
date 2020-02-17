using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Contracts;
using Common.DTOs;
using Domain.Exceptions;
using Domain.MappingConfig;
using Infrastructure.Persistence.Entities;

namespace Domain.Models
{
    public class User : IUser
    {
        private readonly IMapper _mapper;

        private readonly IStorage<UserEntity> _userStorage;
        private readonly TechnologyEntity _techStorage;
        public User()
        {
            _userStorage = new UserEntity();
            _techStorage = new TechnologyEntity();
            _mapper = new InitializeMapper().GetMapper;

        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            UserEntity user = await _userStorage.FindAsync(u => u.Id == id);
            UserDto userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<UserDto> UpdateUserAsync(UserDto user)
        {
            UserEntity userEntity = await _userStorage.FindAsync(u => u.Id == user.Id);
            List<TechnologyEntity> technologiesToDelete = new List<TechnologyEntity>(userEntity.UserTechnologies); 
            userEntity.UserTechnologies.RemoveAll(t => t.UserId == user.Id);
            userEntity.Bio = user.Bio;
            userEntity.Username = user.Username;
            userEntity.Email = user.Email;
            userEntity.LookingForProject = user.LookingForProject;
            userEntity.GitHubUsername = user.GitHubUsername;
            userEntity.UserTechnologies.AddRange(MapTechnologies(user.Technologies));
            await _userStorage.UpdateAsync(userEntity);
            await _techStorage.DeleteAsync(technologiesToDelete);
            UserDto userDto = _mapper.Map<UserDto>(userEntity);
            return userDto;
        }

        private List<TechnologyEntity> MapTechnologies(List<UserTechnologyDto> technologyDtos)
        {
            List<TechnologyEntity> technologies = new List<TechnologyEntity>();
            foreach (var technologyDto in technologyDtos)
            {
                TechnologyEntity techEntity = new TechnologyEntity(){
                    UserId = technologyDto.UserId,
                    Name = technologyDto.Name
                };

                technologies.Add(techEntity);
            }
            return technologies;
        }
    }
}
