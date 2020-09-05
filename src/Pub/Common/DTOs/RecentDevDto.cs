using System;

namespace Common.DTOs
{
    public class RecentDevDto
    {
        public Guid Id { get; set; }
        public string Bio { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
