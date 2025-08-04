// <copyright file="CommandMessage.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using Yunhu.Content;

public record CommandMessage : Message
{
    internal CommandMessage(MessageId id, DateTime time, IContent content, MessageId? parentId, Command command)
        : base(id, time, content, parentId)
    {
        this.Command = command;
    }

    public Command Command { get; }
}