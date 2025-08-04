// <copyright file="EventHeader.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Event;

using Yunhu.Api;

public record EventHeader
{
    internal EventHeader(string eventId, DateTime eventTime, EventType eventType)
    {
        this.EventId = eventId;
        this.EventTime = eventTime;
        this.EventType = eventType;
    }

    public string EventId { get; }

    public DateTime EventTime { get; }

    public EventType EventType { get; }
}