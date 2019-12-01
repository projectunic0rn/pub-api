using System;
using Newtonsoft.Json;

namespace Common.DTOs.GitHubDTOs
{
    public class OrganizationDto
    {
        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "node_id")]
        public string NodeId { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "repos_url")]
        public string ReposUrl { get; set; }
        [JsonProperty(PropertyName = "events_url")]
        public string EventsUrl { get; set; }
        [JsonProperty(PropertyName = "hooks_url")]
        public string HooksUrl { get; set; }
        [JsonProperty(PropertyName = "issues_url")]
        public string IssuesUrl { get; set; }
        [JsonProperty(PropertyName = "members_url")]
        public string MembersUrl { get; set; }
        [JsonProperty(PropertyName = "public_members_url")]
        public string PublicMembersUrl { get; set; }
        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
