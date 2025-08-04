// <copyright file="ChatResponse.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Response;

using Yunhu.Chat.Request;
using Yunhu.Chat.Response.Object;

public class ChatResponse : StandardResponse<ChatRequest>
{
    internal ChatResponse(int code, string message, ChatRequest request, MessageInfo messageInfo)
        : base(code, message, request)
    {
        this.MessageInfo = messageInfo;
    }

    public MessageInfo MessageInfo { get; }
}