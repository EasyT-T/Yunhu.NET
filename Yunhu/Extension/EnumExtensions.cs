// <copyright file="EnumExtensions.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Extension;

using Yunhu.Api;
using Yunhu.Content;

public static class EnumExtensions
{
    public static string ToRequestString(this EventType type)
    {
        return type switch
        {
            EventType.MessageReceiveNormal => "message.receive.normal",
            EventType.MessageReceiveInstruction => "message.receive.instruction",
            EventType.BotFollowed => "bot.followed",
            EventType.BotUnfollowed => "bot.unfollowed",
            EventType.GroupJoin => "group.join",
            EventType.GroupLeave => "group.leave",
            EventType.ButtonReportInline => "button.report.inline",
            EventType.BotShortcutMenu => "bot.shortcut.menu",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        };
    }

    public static string ToRequestString(this ReceiveType type)
    {
        return type switch
        {
            ReceiveType.User => "user",
            ReceiveType.Group => "group",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        };
    }

    public static string ToRequestString(this ContentType type)
    {
        return type switch
        {
            ContentType.Text => "text",
            ContentType.Image => "image",
            ContentType.Video => "video",
            ContentType.File => "file",
            ContentType.Markdown => "markdown",
            ContentType.Html => "html",
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
        };
    }
}