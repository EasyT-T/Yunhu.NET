// <copyright file="ImageChatContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Text.Json.Serialization;
using Yunhu.Api;
using Yunhu.Content;

public class ImageChatContent(ImageKey key, Button[]? buttons = null) : IChatContent
{
    public ContentType Type => ContentType.Image;

    public ImageKey Key { get; } = key;

    public Button[] Buttons { get; } = buttons ?? [];

    public ChatRequest.IChatContentTransfer ToTransfer()
    {
        return new ImageChatContentTransfer
        {
            ImageKey = this.Key.ToString(),
            Buttons = this.Buttons.Length == 0 ? null : this.Buttons.Select(x => x.ToTransfer()).ToArray(),
        };
    }

    public override string ToString()
    {
        return this.Key.ToString();
    }

    public class ImageChatContentTransfer : ChatRequest.IChatContentTransfer
    {
        [JsonPropertyName("imageKey")]
        public required string ImageKey { get; set; }

        public IEnumerable<Button.ButtonTransfer>? Buttons { get; set; }
    }
}