// <copyright file="IButtonAction.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Diagnostics.CodeAnalysis;

public interface IButtonAction
{
    ButtonActionType Type { get; }

    bool TryGetUrl([NotNullWhen(true)] out string? url);

    bool TryGetValue([NotNullWhen(true)] out string? value);
}