// <copyright file="ChatResponseBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Response;

using System.Text.Json;
using Yunhu.Api;
using Yunhu.Chat.Request;
using Yunhu.Chat.Response;
using Yunhu.Chat.Response.Object;
using Yunhu.Util;

public class ChatResponseBuilder : IResponseBuilder<ChatRequest, ChatResponse>
{
    public ChatResponse Build(ChatRequest request, JsonElement raw)
    {
        var code = raw.GetProperty("code").GetInt32();
        var msg = raw.GetProperty("msg").GetString() ?? string.Empty;
        var data = raw.GetProperty("data");

        var messageInfo = data.GetProperty("messageInfo");

        var messageId = messageInfo.GetProperty("msgId").GetString() ?? string.Empty;
        var receiveId = int.Parse(messageInfo.GetProperty("recvId").GetString() ?? string.Empty);
        var receiveType = EnumUtils.ParseReceiveType(messageInfo.GetProperty("recvType").GetString() ?? string.Empty);
        IReceiver receiver;

        switch (receiveType)
        {
            case ReceiveType.User:
                receiver = new UserReceiver(new UserId(receiveId));
                break;
            case ReceiveType.Group:
                receiver = new GroupReceiver(new GroupId(receiveId));
                break;
            default:
                throw new JsonException("Invalid chat response (Unknown receiver type)");
        }

        return new ChatResponse(code, msg, request, new MessageInfo(messageId, receiver));
    }
}