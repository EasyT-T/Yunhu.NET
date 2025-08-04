// <copyright file="ChatRequest.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request;

using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Yunhu.Api;
using Yunhu.Chat.Request.ChatContent;
using Yunhu.Extension;
using Yunhu.Util;

public class ChatRequest(IReceiver target, IChatContent chatContent, MessageId? parent = null) : IRequest
{
    [JsonDerivedType(typeof(FileChatContent.FileChatContentTransfer))]
    [JsonDerivedType(typeof(ImageChatContent.ImageChatContentTransfer))]
    [JsonDerivedType(typeof(MarkdownChatContent.MarkdownChatContentTransfer))]
    [JsonDerivedType(typeof(TextChatContent.TextChatContentTransfer))]
    [JsonDerivedType(typeof(VideoChatContent.VideoChatContentTransfer))]
    public interface IChatContentTransfer
    {
        [JsonPropertyName("buttons")]
        public IEnumerable<Button.ButtonTransfer>? Buttons { get; set; }
    }

    public string ApiUrl => "bot/send";

    public HttpMethod Method { get; } = HttpMethod.Post;

    public HttpContent Content => new StringContent(this.ToRawJson(), Encoding.UTF8, "application/json");

    public IReceiver Target { get; } = target;

    public IChatContent ChatContent { get; } = chatContent;

    public MessageId? Parent { get; } = parent;

    public string ToRawJson()
    {
        var transfer = new ChatRequestTransfer
        {
            ReceiveId = this.Target.Id.Id.ToString(),
            ReceiveType = this.Target.Type.ToRequestString(),
            ContentType = this.ChatContent.Type.ToRequestString(),
            Content = this.ChatContent.ToTransfer(),
            ParentId = this.Parent?.Id,
        };

        return JsonSerializer.Serialize(transfer, SourceGenerationContext.Default.ChatRequestTransfer);
    }

    internal class ChatRequestTransfer
    {
        [JsonPropertyName("recvId")]
        public required string ReceiveId { get; set; }

        [JsonPropertyName("recvType")]
        public required string ReceiveType { get; set; }

        [JsonPropertyName("contentType")]
        public required string ContentType { get; set; }

        [JsonPropertyName("content")]
        public required IChatContentTransfer Content { get; set; }

        [JsonPropertyName("parentId")]
        public string? ParentId { get; set; }
    }
}