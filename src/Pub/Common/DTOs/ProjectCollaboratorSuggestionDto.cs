using System;
namespace Common.DTOs
{
    public class ProjectCollaboratorSuggestionDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
