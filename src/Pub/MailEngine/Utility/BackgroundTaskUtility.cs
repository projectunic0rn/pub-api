using System;

namespace MailEngine.Utility
{
    public static class BackgroundTask
    {
        public static bool ShouldStart(DateTimeOffset? time)
        {
            if(!time.HasValue)
                return false;
            
            DateTimeOffset currentTime = DateTimeOffset.UtcNow;
            DateTimeOffset sendTime = time.Value;

            return currentTime.Hour == sendTime.Hour &&
                   currentTime.Minute >= sendTime.Minute &&
                   currentTime.Minute <= sendTime.Minute + 1;
        }
    }
}