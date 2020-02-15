using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.DTOs.SlackAppDTOs
{
    public class SlackMessageDto
    {
        [JsonProperty("ok")]
        public bool Ok { get; set; }

        [JsonProperty("latest")]
        public string Latest { get; set; }

        [JsonProperty("messages")]
        public List<MessageDetailsDto> Messages { get; set; }

        [JsonProperty("has_more")]
        public bool HasMore { get; set; }

        [JsonProperty("pin_count")]
        public long PinCount { get; set; }

        [JsonProperty("channel_actions_ts")]
        public object ChannelActionsTs { get; set; }

        [JsonProperty("channel_actions_count")]
        public long ChannelActionsCount { get; set; }

        [JsonProperty("response_metadata")]
        public ResponseMetadata ResponseMetadata { get; set; }
    }

    public class MessageDetailsDto
    {
        [JsonProperty("client_msg_id")]
        public Guid ClientMsgId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("ts")]
        public string Ts { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("blocks")]
        public List<Block> Blocks { get; set; }

        [JsonProperty("reactions")]
        public List<Reaction> Reactions { get; set; }
    }

    public class Block
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("block_id")]
        public string BlockId { get; set; }

        [JsonProperty("elements")]
        public List<BlockElement> Elements { get; set; }
    }

    public class BlockElement
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("elements")]
        public List<ElementElementClass> Elements { get; set; }
    }

    public class ElementElementClass
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Reaction
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("users")]
        public List<string> Users { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public class ResponseMetadata
    {
        [JsonProperty("next_cursor")]
        public string NextCursor { get; set; }
    }
}