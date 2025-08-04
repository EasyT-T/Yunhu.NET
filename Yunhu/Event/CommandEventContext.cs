// <copyright file="CommandEventContext.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Event;

using Yunhu.Api;

public record CommandEventContext : MessageEventContext
{
    internal CommandEventContext(User sender, Chat chat, CommandMessage message)
        : base(sender, chat, message)
    {
        this.Message = message;
    }

    public override CommandMessage Message { get; }
}