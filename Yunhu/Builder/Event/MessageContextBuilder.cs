// <copyright file="MessageContextBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Event;
using Yunhu.Transfer;

public class MessageContextBuilder : IEventBuilder<MessageEventContext, MessageEventTransfer>
{
    public MessageEventContext Build(MessageEventTransfer transfer)
    {
        var sender = EventBuilderService.Instance.Build<User, UserTransfer>(transfer.Sender);
        var chat = EventBuilderService.Instance.Build<Chat, ChatTransfer>(transfer.Chat);
        var message = EventBuilderService.Instance.Build<Message, MessageTransfer>(transfer.Message);

        return new MessageEventContext(sender, chat, message);
    }
}