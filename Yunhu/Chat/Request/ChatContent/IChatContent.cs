// <copyright file="IChatContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using Yunhu.Content;

public interface IChatContent
{
    ContentType Type { get; }

    Button[] Buttons { get; }

    ChatRequest.IChatContentTransfer ToTransfer();
}