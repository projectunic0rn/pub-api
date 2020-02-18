using System;
using System.Collections.Generic;

namespace Common.DTOs
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public bool LookingForProject { get; set; }
        public string GitHubUsername { get; set; }
        public List<UserTechnologyDto> Technologies { get; set; }
        public List<ProjectUserDto> ProjectUsers { get; set; }

    }
}
