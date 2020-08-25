using System;
using System.Collections.Generic;

namespace Common.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CommunicationPlatformUrl { get; set; }
        public string RepositoryUrl { get; set; }
        public string CommunicationPlatform { get; set; }
        public bool Searchable { get; set; }
        public List<ProjectTechnologyDto> ProjectTechnologies { get; set; }
        public List<ProjectUserDto> ProjectUsers { get; set; }
    }
}