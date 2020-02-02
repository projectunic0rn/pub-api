using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs;
using Common.Models;
using Infrastructure.Persistence.Entities;
using System.Collections.Generic;
using AutoMapper;
using Domain.MappingConfig;

namespace Domain.Helpers
{
    public class Utilities : IUtilities
    {
        private readonly IMapper _mapper;
        private readonly IStorage<UserEntity> _userStorage;
        private readonly IStorage<ProjectTypeEntity> _projectTypesStorage;
        private User _user;

        public Utilities()
        {
            _user = new User();
            _userStorage = new UserEntity();
            _projectTypesStorage = new ProjectTypeEntity();
            _mapper = new InitializeMapper().GetMapper;
        }

        public async Task<ValidationDto> ValidateUsernameAsync(string username)
        {
            ValidationDto validationDto = new ValidationDto(false, "Username is unavailable");

            // check for special case if username
            // starts with unicorn since this is a 
            // reserved string used for generating usernames
            // see GenerateUsername() method inside EventHandler.cs
            if (username.StartsWith("unicorn"))
            {
                validationDto.Valid = false;
                validationDto.Reason = "Username is unavailable";
                return validationDto;
            }

            if (!_user.ValidUsernameMaxLength(username))
            {
                validationDto.Valid = false;
                validationDto.Reason = "Your username must be shorter than 15 characters.";
                return validationDto;
            }

            if (!_user.ValidUsernameMinLength(username))
            {
                validationDto.Valid = false;
                validationDto.Reason = "Your username must be at least 1 character.";
                return validationDto;
            }

            if (!_user.ValidUsernameCharacters(username))
            {
                validationDto.Valid = false;
                validationDto.Reason = "Your username can only contain letters, numbers and '_'";
                return validationDto;
            }

            var user = await _userStorage.FindAsync(u => u.Username == username);
            if (user == null)
            {
                validationDto.Valid = true;
                validationDto.Reason = "Username is available";
                return validationDto;
            }

            return validationDto;
        }

        public async Task<List<ProjectTypeDto>> GetProjectTypesAsync()
        {
            var projectTypes = await _projectTypesStorage.FindAsync();
            var projectTypesDto = _mapper.Map<List<ProjectTypeDto>>(projectTypes);
            return projectTypesDto;
        }
    }
}
