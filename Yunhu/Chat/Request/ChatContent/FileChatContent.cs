// <copyright file="FileChatContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Text.Json.Serialization;
using Yunhu.Api;
using ContentType = Yunhu.Content.ContentType;

public class FileChatContent(FileKey key, Button[]? buttons = null) : IChatContent
{
    public ContentType Type => ContentType.File;

    public FileKey Key { get; } = key;

    public Button[] Buttons { get; } = buttons ?? [];

    public ChatRequest.IChatContentTransfer ToTransfer()
    {
        return new FileChatContentTransfer
        {
            FileKey = this.Key.ToString(),
            Buttons = this.Buttons.Length == 0 ? null : this.Buttons.Select(x => x.ToTransfer()).ToArray(),
        };
    }

    public override string ToString()
    {
        return this.Key.ToString();
    }

    public class FileChatContentTransfer : ChatRequest.IChatContentTransfer
    {
        [JsonPropertyName("fileKey")]
        public required string FileKey { get; set; }

        public IEnumerable<Button.ButtonTransfer>? Buttons { get; set; }
    }
}