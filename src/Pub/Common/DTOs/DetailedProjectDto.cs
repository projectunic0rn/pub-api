using System;
using System.Collections.Generic;

namespace Common.DTOs
{
    public class DetailedProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExtendedMarkdownDescription { get; set; }
        public string RepositoryUrl { get; set; }
        public string CommunicationPlatformUrl { get; set; }
        public string CommunicationPlatform { get; set; }
        public List<ProjectTechnologyDto> ProjectTechnologies { get; set; }
        public List<DetailedProjectUserDto> ProjectUsers { get; set; }
    }
}
