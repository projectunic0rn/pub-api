using System.Collections.Generic;

namespace Common.DTOs
{
    public class NotificationDto
    {
        public NotificationDto(string content, string type)
        {
            Content = content;
            NotificationType = type;
        }
        public string Content { get; set; }
        public string NotificationType { get; set; }
        public List<string> NotificationRecipients { get; set; }
    }
}