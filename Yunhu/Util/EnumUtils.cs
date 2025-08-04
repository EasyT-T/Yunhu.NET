// <copyright file="EnumUtils.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Util;

using Yunhu.Api;
using Yunhu.Content;

public static class EnumUtils
{
    public static ChatType ParseChatType(string raw)
    {
        return raw switch
        {
            "bot" => ChatType.Bot,
            "group" => ChatType.Group,
            _ => throw new ArgumentOutOfRangeException(raw),
        };
    }

    public static UserType ParseUserType(string raw)
    {
        return raw switch
        {
            "user" => UserType.User,
            "bot" => UserType.Bot,
            _ => throw new ArgumentOutOfRangeException(raw),
        };
    }

    public static UserLevel ParseUserLevel(string raw)
    {
        return raw switch
        {
            "owner" => UserLevel.Owner,
            "administrator" => UserLevel.Administrator,
            "member" => UserLevel.Member,
            "unknown" => UserLevel.Unknown,
            _ => throw new ArgumentOutOfRangeException(raw),
        };
    }

    public static EventType ParseEventType(string raw)
    {
        return raw switch
        {
            "message.receive.normal" => EventType.MessageReceiveNormal,
            "message.receive.instruction" => EventType.MessageReceiveInstruction,
            "bot.followed" => EventType.BotFollowed,
            "bot.unfollowed" => EventType.BotUnfollowed,
            "group.join" => EventType.GroupJoin,
            "group.leave" => EventType.GroupLeave,
            "button.report.inline" => EventType.ButtonReportInline,
            "bot.shortcut.menu" => EventType.BotShortcutMenu,
            _ => throw new ArgumentOutOfRangeException(raw),
        };
    }

    public static ContentType ParseContentType(string raw)
    {
        return raw switch
        {
            "text" => ContentType.Text,
            "image" => ContentType.Image,
            "markdown" => ContentType.Markdown,
            "html" => ContentType.Html,
            "video" => ContentType.Video,
            "file" => ContentType.File,
            _ => throw new ArgumentOutOfRangeException(raw),
        };
    }

    public static ReceiveType ParseReceiveType(string raw)
    {
        return raw switch
        {
            "user" => ReceiveType.User,
            "group" => ReceiveType.Group,
            _ => throw new ArgumentOutOfRangeException(raw),
        };
    }
}