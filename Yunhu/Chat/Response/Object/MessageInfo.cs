// <copyright file="MessageInfo.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Response.Object;

using Yunhu.Api;

public record MessageInfo
{
    internal MessageInfo(string messageId, IReceiver receiver)
    {
        this.MessageId = messageId;
        this.Receiver = receiver;
    }

    public string MessageId { get; }

    public IReceiver Receiver { get; set; }
}