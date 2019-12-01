using System;
using Newtonsoft.Json;
namespace Common.DTOs.GitHubDTOs
{
    public class AccessTokenDto
    {
        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }
        [JsonProperty(PropertyName = "expires_at")]
        public string ExpiresAt { get; set; }
    }
}
