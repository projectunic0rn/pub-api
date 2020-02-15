using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class ReactionEventDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("reaction")]
        public string Reaction { get; set; }

        [JsonProperty("item_user")]
        public string ItemUser { get; set; }

        [JsonProperty("item")]
        public Item Item { get; set; }

        [JsonProperty("event_ts")]
        public string EventTs { get; set; }
    }
}