// <copyright file="Chat.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

public record Chat
{
    internal Chat(IAcceptableId chatId, ChatType chatType)
    {
        this.ChatId = chatId;
        this.ChatType = chatType;
    }

    public IAcceptableId ChatId { get; }

    public ChatType ChatType { get; }
}