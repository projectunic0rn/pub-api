using System;

namespace Common.DTOs
{
    public class ProjectUserDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public bool IsOwner { get; set; }
    }
}