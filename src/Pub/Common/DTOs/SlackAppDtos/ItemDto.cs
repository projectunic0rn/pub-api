using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class Item
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("ts")]
        public string Ts { get; set; }
    }
}