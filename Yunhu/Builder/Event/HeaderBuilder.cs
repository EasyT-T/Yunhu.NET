// <copyright file="HeaderBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Event;
using Yunhu.Transfer;
using Yunhu.Util;

public class HeaderBuilder : IEventBuilder<EventHeader, HeaderTransfer>
{
    public EventHeader Build(HeaderTransfer transfer)
    {
        var eventId = transfer.EventId;
        var eventTime = DateTimeOffset.FromUnixTimeMilliseconds(transfer.EventTime).LocalDateTime;
        var eventType = EnumUtils.ParseEventType(transfer.EventType);

        return new EventHeader(eventId, eventTime, eventType);
    }
}