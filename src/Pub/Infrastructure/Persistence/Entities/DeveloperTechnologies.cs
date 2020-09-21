using System;

namespace Infrastructure.Persistence.Entities
{
    public class DeveloperTechnologies
    {
        public Guid UserId { get; set; }
        public string WorkspaceMemberId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
