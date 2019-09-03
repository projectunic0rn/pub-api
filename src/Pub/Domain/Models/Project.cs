using System;

namespace Domain.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
        public int ProjectType { get; set; }
        public string RepositoryLink { get; set; }
        public string InvitationLink { get; set; }
    }
}