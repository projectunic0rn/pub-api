using System;

namespace Common.DTOs
{
    public class NotificationDto
    {
        
        public NotificationDto(string content)
        {
            Content = content;
        }

        /// <summary>
        /// New up NotificationDto object with the Guid Id
        /// of the member being notified.
        /// </summary>
        /// <param name="notificantId">guid id of member being notified</param>
        public NotificationDto(Guid? notificantId)
        {
            NotificantId = notificantId;
        }

        public string Content { get; set; }
        public Guid? NotificantId { get; set; }
        public object NotificationObject { get; set; }
    }
}