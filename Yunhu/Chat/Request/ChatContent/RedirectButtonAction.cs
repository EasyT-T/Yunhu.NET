// <copyright file="RedirectButtonAction.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Diagnostics.CodeAnalysis;

public record RedirectButtonAction(string Url) : IButtonAction
{
    public ButtonActionType Type => ButtonActionType.Redirect;

    public bool TryGetUrl([NotNullWhen(true)] out string? url)
    {
        url = this.Url;

        return true;
    }

    public bool TryGetValue([NotNullWhen(true)] out string? value)
    {
        value = null;

        return false;
    }
}