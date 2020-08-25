using System;

namespace Common.DTOs
{
    public class DetailedProjectUserDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Timezone { get; set; }
        public string FullName { get; set; }
        public bool IsOwner { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
