using System;

namespace Common.DTOs
{
    public class RecentDevsDto
    {
        public Guid Id { get; set; }
        public string Bio { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
