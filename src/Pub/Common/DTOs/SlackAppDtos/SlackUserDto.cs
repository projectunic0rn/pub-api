using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class SlackUserDto
    {
        [JsonProperty(PropertyName = "id")]
        public string SlackId { get; set; }
        [JsonProperty(PropertyName = "team_id")]
        public string SlackTeamId { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "deleted")]
        public bool SlackDeleted { get; set; }
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }
        [JsonProperty(PropertyName = "real_name")]
        public string DisplayName { get; set; }
        [JsonProperty(PropertyName = "tz")]
        public string Timezone { get; set; }
        [JsonProperty(PropertyName = "tz_label")]
        public string TimezoneLabel { get; set; }
        [JsonProperty(PropertyName = "tz_offset")]
        public int TimezoneLabelOffset { get; set; }
        [JsonProperty(PropertyName = "profile")]
        public SlackProfileDto Profile { get; set; }
        [JsonProperty(PropertyName = "is_admin")]
        public bool IsAdmin { get; set; }
        [JsonProperty(PropertyName = "is_owner")]
        public bool IsOwner { get; set; }
        [JsonProperty(PropertyName = "is_primary_owner")]
        public bool IsPrimaryOwner { get; set; }
        [JsonProperty(PropertyName = "is_restricted")]
        public bool IsRestricted { get; set; }
        [JsonProperty(PropertyName = "is_ultra_restricted")]
        public bool IsUltraRestricted { get; set; }
        [JsonProperty(PropertyName = "is_bot")]
        public bool IsBot { get; set; }
        [JsonProperty(PropertyName = "is_stranger")]
        public bool IsStranger { get; set; }
        [JsonProperty(PropertyName = "updated")]
        public int Updated { get; set; }
        [JsonProperty(PropertyName = "is_app_user")]
        public bool IsAppUser { get; set; }
        [JsonProperty(PropertyName = "has_2fa")]
        public bool Has2fa { get; set; }
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
    }
    
    public class SlackProfileDto
    {
        [JsonProperty(PropertyName = "avatar_hash")]
        public string AvatarHash { get; set; }
        [JsonProperty(PropertyName = "status_text")]
        public string StatusText { get; set; }
        [JsonProperty(PropertyName = "status_emoji")]
        public string StatusEmoji { get; set; }
        [JsonProperty(PropertyName = "status_expiration")]
        public int StatusExpiration { get; set; }
        [JsonProperty(PropertyName = "real_name")]
        public string RealName { get; set; }
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }
        [JsonProperty(PropertyName = "real_name_normalized")]
        public string RealNameNormalized { get; set; }
        [JsonProperty(PropertyName = "display_name_normalized")]
        public string DisplayNameNormalized { get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "image_original")]
        public string ImageOriginal { get; set; }
        [JsonProperty(PropertyName = "image_24")]
        public string Image24 { get; set; }
        [JsonProperty(PropertyName = "image_32")]
        public string Image32 { get; set; }
        [JsonProperty(PropertyName = "image_48")]
        public string Image48 { get; set; }
        [JsonProperty(PropertyName = "image_72")]
        public string Image72 { get; set; }
        [JsonProperty(PropertyName = "image_192")]
        public string Image192 { get; set; }
        [JsonProperty(PropertyName = "image_512")]
        public string Image512 { get; set; }
        [JsonProperty(PropertyName = "team")]
        public string Team { get; set; }
    }
}
