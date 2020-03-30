using System;

namespace Common.DTOs
{
    public class NotificationDto
    {
        
        public NotificationDto(string content)
        {
            Content = content;
        }

        public NotificationDto(Guid? notifierId)
        {
            NotifierId = notifierId;
        }

        public string Content { get; set; }
        public Guid? NotifierId { get; set; }
        public object NotificationObject { get; set; }
    }
}