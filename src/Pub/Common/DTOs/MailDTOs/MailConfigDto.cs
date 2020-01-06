using System;

namespace Common.DTOs.MailDTOs
{
    public class MailConfigDto
    {
        public MailConfigDto()
        {

        }
        public MailConfigDto(string mailName, MailType type, string templateId, int intervalSeconds, DateTimeOffset? lastSend, DateTimeOffset? nextSend)
        {
            Name = mailName;
            Type = type;
            TemplateId = templateId;
            IntervalSeconds = intervalSeconds;
            LastSend = lastSend;
            NextSend = nextSend;
        }

        public string Name { get; set; }
        public MailType Type { get; set; }
        public string TemplateId { get; set; }
        public int IntervalSeconds { get; set; }
        public DateTimeOffset? LastSend { get; set; }
        public DateTimeOffset? NextSend { get; set; }
    }

    public enum MailType
    {
        Transactional = 0,
        Scheduled = 1
    }

    public enum MailName
    {
        ProjectRecommendations = 0,
        ProjectLaunchShowcase = 1,
        WelcomeMessage = 2,
        FeedbackMessage = 3
    }
}
