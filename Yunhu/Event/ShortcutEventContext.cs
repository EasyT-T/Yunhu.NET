// <copyright file="ShortcutEventContext.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Event;

using Yunhu.Api;

public record ShortcutEventContext
{
    internal ShortcutEventContext(
        int botId,
        string menuId,
        MenuType menuType,
        int menuAction,
        Chat chat,
        UserId senderId,
        DateTime time)
    {
        this.BotId = botId;
        this.MenuId = menuId;
        this.MenuType = menuType;
        this.MenuAction = menuAction;
        this.Chat = chat;
        this.SenderId = senderId;
        this.Time = time;
    }

    public int BotId { get; }

    public string MenuId { get; }

    public MenuType MenuType { get; }

    public int MenuAction { get; }

    public Chat Chat { get; }

    public UserId SenderId { get; }

    public DateTime Time { get; }
}