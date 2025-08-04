// <copyright file="Message.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using Yunhu.Content;

public record Message
{
    internal Message(MessageId id, DateTime time, IContent content, MessageId? parentId)
    {
        this.Id = id;
        this.Time = time;
        this.Content = content;
        this.ParentId = parentId;
    }

    public MessageId Id { get; }

    public DateTime Time { get; }

    public IContent Content { get; }

    public MessageId? ParentId { get; }
}