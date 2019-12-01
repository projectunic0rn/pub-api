using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class TeamJoinEventDto
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "event_ts")]
        public string EventTs { get; set; }
        [JsonProperty(PropertyName = "user")]
        public SlackUserDto User { get; set; }
    }
}
