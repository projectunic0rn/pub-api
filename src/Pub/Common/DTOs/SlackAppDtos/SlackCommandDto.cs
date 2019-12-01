using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class SlackCommandDto
    {
        [JsonProperty(PropertyName = "team_id")]
        public string team_id { get; set; }
        [JsonProperty(PropertyName = "team_domain")]
        public string team_domain { get; set; }
        [JsonProperty(PropertyName = "enterprise_id")]
        public string enterprise_id { get; set; }
        [JsonProperty(PropertyName = "enterprise_name")]
        public string enterprise_name { get; set; }
        [JsonProperty(PropertyName = "channel_id")]
        public string channel_id { get; set; }
        [JsonProperty(PropertyName = "channel_name")]
        public string channel_name { get; set; }
        [JsonProperty(PropertyName = "user_id")]
        public string user_id { get; set; }
        [JsonProperty(PropertyName = "user_name")]
        public string user_name { get; set; }
        [JsonProperty(PropertyName = "command")]
        public string command { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string text { get; set; }
        [JsonProperty(PropertyName = "response_url")]
        public string response_url { get; set; }
        [JsonProperty(PropertyName = "trigger_id")]
        public string trigger_id { get; set; }
    }
}
