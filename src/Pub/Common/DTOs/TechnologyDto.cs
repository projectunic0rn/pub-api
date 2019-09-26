using System;
namespace Common.DTOs
{
    public class ProjectTechnologyDto
    {
        public string Name { get; set; }
        public Guid? ProjectId { get; set; }
    }

    public class UserTechnologyDto
    {
        public string Name { get; set; }
        public Guid? UserId { get; set; }
    }
}
