using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mailer.DTOs
{
    public class SendGridMailMessage
    {
        [JsonProperty("personalizations")]
        public Personalization[] Personalizations { get; set; }

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("reply_to")]
        public From ReplyTo { get; set; }
        [JsonProperty("content")]
        public Content[] Content { get; set; }


        [JsonProperty("template_id")]
        public string TemplateId { get; set; }
    }

    public class From
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Personalization
    {
        [JsonProperty("to")]
        public From[] To { get; set; }

        [JsonProperty("dynamic_template_data")]
        public DynamicTemplateData DynamicTemplateData { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }
    }

    public class Content {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class DynamicTemplateData
    {
        [JsonProperty("verb")]
        public string Verb { get; set; }

        [JsonProperty("adjective")]
        public string Adjective { get; set; }

        [JsonProperty("noun")]
        public string Noun { get; set; }

        [JsonProperty("currentDayofWeek")]
        public string CurrentDayofWeek { get; set; }
    }
}