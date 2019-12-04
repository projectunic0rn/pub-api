using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class SlackEventFullDto<EventType>
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "challenge")]
        public string Challenge { get; set; }
        [JsonProperty(PropertyName = "team_id")]
        public string TeamId { get; set; }
        [JsonProperty(PropertyName = "api_app_id")]
        public string ApiAppId { get; set; }
        [JsonProperty(PropertyName = "event")]
        public EventType Event { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "authed_users")]
        public List<string> AuthedUsers { get; set; }
        [JsonProperty(PropertyName = "event_id")]
        public string EventId { get; set; }
        [JsonProperty(PropertyName = "event_time")]
        public int EventTime { get; set; }
    }
}
