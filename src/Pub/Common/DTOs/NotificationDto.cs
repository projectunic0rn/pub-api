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
            NotificantId = notifierId;
        }

        public string Content { get; set; }
        public Guid? NotificantId { get; set; }
        public object NotificationObject { get; set; }
    }
}