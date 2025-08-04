// <copyright file="VideoChatContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Text.Json.Serialization;
using Yunhu.Api;
using Yunhu.Content;

public class VideoChatContent(VideoKey key, Button[]? buttons = null) : IChatContent
{
    public ContentType Type => ContentType.Video;

    public VideoKey Key { get; } = key;

    public Button[] Buttons { get; } = buttons ?? [];

    public ChatRequest.IChatContentTransfer ToTransfer()
    {
        return new VideoChatContentTransfer
        {
            VideoKey = this.Key.ToString(),
            Buttons = this.Buttons.Length == 0 ? null : this.Buttons.Select(x => x.ToTransfer()),
        };
    }

    public class VideoChatContentTransfer : ChatRequest.IChatContentTransfer
    {
        [JsonPropertyName("videoKey")]
        public required string VideoKey { get; set; }

        public IEnumerable<Button.ButtonTransfer>? Buttons { get; set; }
    }
}