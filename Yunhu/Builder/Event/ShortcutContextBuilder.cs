// <copyright file="ShortcutContextBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Event;
using Yunhu.Transfer;
using Yunhu.Util;

public class ShortcutContextBuilder : IEventBuilder<ShortcutEventContext, ShortcutEventTransfer>
{
    public ShortcutEventContext Build(ShortcutEventTransfer transfer)
    {
        var botId = int.Parse(transfer.BotId);
        var menuId = transfer.MenuId;
        var menuType = transfer.MenuType;
        var menuAction = transfer.MenuAction;
        var chatType = EnumUtils.ParseChatType(transfer.ChatType);

        IAcceptableId chatId = chatType switch
        {
            ChatType.Bot => new UserId(int.Parse(transfer.ChatId)),
            ChatType.Group => new GroupId(int.Parse(transfer.ChatId)),
            _ => throw new Exception("Invalid shortcut context (Unknown chat type)"),
        };

        var chat = new Chat(chatId, chatType);
        _ = EnumUtils.ParseUserType(transfer.SenderType); // Drop this
        var senderId = new UserId(int.Parse(transfer.SenderId));
        var sendTime = DateTimeOffset.FromUnixTimeSeconds(transfer.SendTime).LocalDateTime;

        return new ShortcutEventContext(botId, menuId, menuType, menuAction, chat, senderId, sendTime);
    }
}