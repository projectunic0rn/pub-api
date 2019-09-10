using System.Threading.Tasks;
using Common.Contracts;
using Common.DTOs;
using Domain.Models;
using Infrastructure.Persistence.Entities;

namespace Domain.Helpers
{
    public class Utilities : IUtilities
    {
        private readonly IStorage<UserEntity> _storage;
        private User _user;

        public Utilities()
        {
            _user = new User();
            _storage = new UserEntity();
        }

        public async Task<ValidationDto> ValidateUsernameAsync(string username)
        {
            ValidationDto validationDto = new ValidationDto(false, "Username is unavailable");

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

            var user = await _storage.FindAsync(u => u.Username == username);
            if(user == null)
            {
                validationDto.Valid = true;
                validationDto.Reason = "Username is available";
                return validationDto;
             }
            
            return validationDto;
        }
        
    }
}
