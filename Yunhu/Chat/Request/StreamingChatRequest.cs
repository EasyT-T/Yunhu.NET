// <copyright file="StreamingChatRequest.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request;

using Yunhu.Api;
using Yunhu.Extension;

public class StreamingChatRequest(IEnumerator<string> messages, IReceiver receiver, bool isMarkdown = false) : IRequest
{
    public string ApiUrl =>
        $"bot/send-stream?recvId={receiver.Id}&recvType={receiver.Type.ToRequestString()}&contentType={this.GetContentType()}";

    public HttpMethod Method { get; } = HttpMethod.Post;

    public HttpContent Content => new StreamingChatContent(messages);

    private string GetContentType()
    {
        return isMarkdown ? "text" : "markdown";
    }
}