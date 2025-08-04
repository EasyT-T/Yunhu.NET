// <copyright file="StreamingChatResponse.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Response;

using Yunhu.Api;
using Yunhu.Chat.Request;
using Yunhu.Chat.Response.Object;

public class StreamingChatResponse : StandardResponse<StreamingChatRequest>
{
    internal StreamingChatResponse(int code, string message, StreamingChatRequest request, MessageInfo messageInfo)
        : base(code, message, request)
    {
        this.MessageInfo = messageInfo;
    }

    public MessageInfo MessageInfo { get; }
}