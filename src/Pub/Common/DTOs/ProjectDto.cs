using System;

namespace API.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset LaunchDate { get; set; }
        public Guid ProjectTypeId { get; set; }
        public string RepositoryUrl { get; set; }
        public string CommunicationPlatformUrl { get; set; }
        public bool LookingForMembers { get; set; }
        public Guid CommunicationPlatformOd { get; set; }
    }
}