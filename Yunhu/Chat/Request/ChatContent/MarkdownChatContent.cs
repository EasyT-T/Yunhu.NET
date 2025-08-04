// <copyright file="MarkdownChatContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Text.Json.Serialization;
using Yunhu.Content;

public class MarkdownChatContent(string text, Button[]? buttons = null) : IChatContent
{
    public ContentType Type => ContentType.Markdown;

    public string Text { get; } = text;

    public Button[] Buttons { get; } = buttons ?? [];

    public ChatRequest.IChatContentTransfer ToTransfer()
    {
        return new MarkdownChatContentTransfer
        {
            Text = this.Text,
            Buttons = this.Buttons.Length == 0 ? null : this.Buttons.Select(x => x.ToTransfer()).ToArray(),
        };
    }

    public override string ToString()
    {
        return this.Text;
    }

    public class MarkdownChatContentTransfer : ChatRequest.IChatContentTransfer
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        public IEnumerable<Button.ButtonTransfer>? Buttons { get; set; }
    }
}