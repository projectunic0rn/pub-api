using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MailEngine.DTOs
{
    public class SendGridTemplateDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("versions")]
        public List<Version> Versions { get; set; }
    }

    public class Version
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("template_id")]
        public string TemplateId { get; set; }

        [JsonProperty("active")]
        public long Active { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("html_content")]
        public string HtmlContent { get; set; }

        [JsonProperty("plain_content")]
        public string PlainContent { get; set; }

        [JsonProperty("editor")]
        public string Editor { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
        [JsonProperty("thumbnail_url")]
        public string ThumbnailUrl { get; set; }
        [JsonProperty("generate_plain_content")]
        public bool GeneratePlainContent { get; set; }
    }
}