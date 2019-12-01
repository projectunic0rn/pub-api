using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class SlackUserInfoDto
    {
        [JsonProperty(PropertyName = "ok")]
        public bool Ok { get; set; }
        [JsonProperty(PropertyName = "user")]
        public SlackUserDto User { get; set; }
    }
}
