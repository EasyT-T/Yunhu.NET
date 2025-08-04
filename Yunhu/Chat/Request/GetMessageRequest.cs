// <copyright file="GetMessageRequest.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request;

using System.Text.Json;
using System.Text.Json.Serialization;
using Yunhu.Api;
using Yunhu.Extension;
using Yunhu.Util;

public class GetMessageRequest(IReceiver receiver, MessageId messageId) : IRequest
{
    public string ApiUrl => "bot/messages?" + string.Join("&", this.GetQuery());

    public HttpMethod Method { get; } = HttpMethod.Get;

    public HttpContent? Content => null;

    public IReceiver Receiver { get; } = receiver;

    public MessageId MessageId { get; } = messageId;

    public IEnumerable<string> GetQuery()
    {
        yield return $"chat-id={this.Receiver.Id}";

        yield return $"chat-type={this.Receiver.Type.ToRequestString()}";

        yield return $"message-id={this.MessageId}";

        yield return "before=1";
    }
}