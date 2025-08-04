// <copyright file="GetMessageResponse.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Response;

using Yunhu.Api;
using Yunhu.Chat.Request;

public class GetMessageResponse : StandardResponse<GetMessageRequest>
{
    internal GetMessageResponse(int code, string message, GetMessageRequest request, User sender, Message messageResultResult)
        : base(code, message, request)
    {
        this.Sender = sender;
        this.MessageResult = messageResultResult;
    }

    public User Sender { get; }

    public Message MessageResult { get; }
}