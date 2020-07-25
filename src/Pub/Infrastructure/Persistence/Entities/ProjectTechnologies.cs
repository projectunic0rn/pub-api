using System;
namespace Infrastructure.Persistence.Entities
{
    public class ProjectTechnologies
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ProjectWorkspaceLink { get; set; }
        public string TechnologyName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
