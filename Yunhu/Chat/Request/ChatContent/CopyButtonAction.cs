// <copyright file="CopyButtonAction.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Diagnostics.CodeAnalysis;

public record CopyButtonAction(string Value) : IButtonAction
{
    public ButtonActionType Type => ButtonActionType.Copy;

    public bool TryGetUrl([NotNullWhen(true)] out string? url)
    {
        url = null;

        return false;
    }

    public bool TryGetValue([NotNullWhen(true)] out string? value)
    {
        value = this.Value;

        return true;
    }
}