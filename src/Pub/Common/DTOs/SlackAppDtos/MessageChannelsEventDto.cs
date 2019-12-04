using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class MessageChannelsEventDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("ts")]
        public string Ts { get; set; }

        [JsonProperty("event_ts")]
        public string EventTs { get; set; }

        [JsonProperty("channel_type")]
        public string ChannelType { get; set; }
    }
}
