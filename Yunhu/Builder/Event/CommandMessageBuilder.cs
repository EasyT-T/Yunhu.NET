// <copyright file="CommandMessageBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Transfer;

public class CommandMessageBuilder : MessageBuilder, IEventBuilder<CommandMessage, CommandMessageTransfer>
{
    public CommandMessage Build(CommandMessageTransfer transfer)
    {
        var message = base.Build(transfer);
        var commandId = transfer.CommandId;
        var commandName = transfer.CommandName;
        var command = new Command(commandId, commandName);

        return new CommandMessage(message.Id, message.Time, message.Content, message.ParentId, command);
    }
}