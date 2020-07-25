using System;

namespace Infrastructure.Persistence.Entities
{
    public class DeveloperTechnologies
    {
        public string WorkspaceMemberId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
