using System;
using System.Text.RegularExpressions;

namespace Common.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string username, string email, string timezone, string locale, bool lookingForProject, string gitHubUsername = "", string profilePictureUrl = "")
        {
            Username = username;
            Email = email;
            Timezone = timezone;
            Locale = locale;
            LookingForProject = lookingForProject;
            ProfilePictureUrl = profilePictureUrl;
            GitHubUsername = gitHubUsername;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Timezone { get; set; }
        public string Locale { get; set; }
        public bool LookingForProject { get; set; }
        public string GitHubUsername { get; set; }
        public string ProfilePictureUrl { get; set; }

        public bool ValidUsernameCharacters(string username)
        {
            return Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$");
        }

        public bool ValidUsernameMaxLength(string username)
        {
            return username.Length < 15;
        }

        public bool ValidUsernameMinLength(string username)
        {
            return username.Length >= 1;
        }

    }
}
