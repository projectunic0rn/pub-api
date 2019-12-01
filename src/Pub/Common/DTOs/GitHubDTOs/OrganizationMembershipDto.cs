using System;
using Newtonsoft.Json;

namespace Common.DTOs.GitHubDTOs
{
    public class OrganizationMembershipDto
    {
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
        [JsonProperty(PropertyName = "organization_url")]
        public string OrganizationUrl { get; set; }
        [JsonProperty(PropertyName = "organization")]
        public OrganizationDto Organization { get; set; }
        [JsonProperty(PropertyName = "user")]
        public UserDto User { get; set; }
    }
}
