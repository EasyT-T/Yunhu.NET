// <copyright file="MessageBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Builder.Content;
using Yunhu.Content;
using Yunhu.Transfer;
using Yunhu.Util;

public class MessageBuilder : IEventBuilder<Message, MessageTransfer>
{
    public Message Build(MessageTransfer transfer)
    {
        var id = new MessageId(transfer.MsgId);
        var time = DateTimeOffset.FromUnixTimeMilliseconds(transfer.SendTime).LocalDateTime;
        var contentType = EnumUtils.ParseContentType(transfer.ContentType);
        var content = ContentBuilderService.Instance.Build(contentType, transfer.Content);
        var parentId = transfer.ParentId;

        return new Message(
            id,
            time,
            content,
            string.IsNullOrEmpty(parentId) ? null : new MessageId(parentId));
    }
}