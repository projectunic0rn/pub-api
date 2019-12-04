using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class EventType
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "subtype")]
        public string SubType { get; set; }
    }
}
