// <copyright file="CommandContextBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Event;
using Yunhu.Transfer;

public class CommandContextBuilder : IEventBuilder<CommandEventContext, CommandEventTransfer>
{
    public CommandEventContext Build(CommandEventTransfer transfer)
    {
        var sender = EventBuilderService.Instance.Build<User, UserTransfer>(transfer.Sender);
        var chat = EventBuilderService.Instance.Build<Chat, ChatTransfer>(transfer.Chat);
        var message = EventBuilderService.Instance.Build<CommandMessage, CommandMessageTransfer>(transfer.Message);

        return new CommandEventContext(sender, chat, message);
    }
}