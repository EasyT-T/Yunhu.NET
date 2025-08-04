// <copyright file="ChatBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Transfer;
using Yunhu.Util;

public class ChatBuilder : IEventBuilder<Chat, ChatTransfer>
{
    public Chat Build(ChatTransfer transfer)
    {
        var chatType = EnumUtils.ParseChatType(transfer.ChatType);
        IAcceptableId chatId = chatType switch
        {
            ChatType.Bot => new UserId(int.Parse(transfer.ChatId)),
            ChatType.Group => new GroupId(int.Parse(transfer.ChatId)),
            _ => throw new Exception("Invalid chat (Unknown chat type)"),
        };

        return new Chat(chatId, chatType);
    }
}