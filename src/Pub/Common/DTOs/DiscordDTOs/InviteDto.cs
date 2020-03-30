using System;
using Newtonsoft.Json;

namespace Common.DTOs.DiscordDTOs
{
    public class InviteDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("guild")]
        public Guild Guild { get; set; }
        [JsonProperty("channel")]
        public Channel Channel { get; set; }
        [JsonProperty("inviter")]
        public Inviter Inviter { get; set; }
        [JsonProperty("target_user")]
        public Inviter TargetUser { get; set; }
        [JsonProperty("target_user_type")]
        public long TargetUserType { get; set; }
    }

    public class Channel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("type")]
        public long Type { get; set; }
    }

    public class Guild
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("splash")]
        public object Splash { get; set; }
        [JsonProperty("icon")]
        public object Icon { get; set; }
    }

    public class Inviter
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("avatar")]
        public string Avatar { get; set; }
        [JsonProperty("discriminator")]
        public long Discriminator { get; set; }
    }
}
