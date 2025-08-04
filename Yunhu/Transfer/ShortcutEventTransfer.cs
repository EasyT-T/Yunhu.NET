// <copyright file="ShortcutEventTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

using Yunhu.Api;

public class ShortcutEventTransfer : ITransfer
{
    public required string BotId { get; set; }

    public required string MenuId { get; set; }

    public required MenuType MenuType { get; set; }

    public required int MenuAction { get; set; }

    public required string ChatId { get; set; }

    public required string ChatType { get; set; }

    public required string SenderType { get; set; }

    public required string SenderId { get; set; }

    public required long SendTime { get; set; }
}