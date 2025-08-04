// <copyright file="MessageEventContext.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Event;

using Yunhu.Api;

public record MessageEventContext
{
    internal MessageEventContext(User sender, Chat chat, Message message)
    {
        this.Sender = sender;
        this.Chat = chat;
        this.Message = message;
    }

    public User Sender { get; }

    public Chat Chat { get; }

    public virtual Message Message { get; }
}