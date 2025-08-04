// <copyright file="GetMessageResponseBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Response;

using System.Text.Json;
using Yunhu.Api;
using Yunhu.Builder.Content;
using Yunhu.Chat.Request;
using Yunhu.Chat.Response;
using Yunhu.Util;

public class GetMessageResponseBuilder : IResponseBuilder<GetMessageRequest, GetMessageResponse>
{
    public GetMessageResponse Build(GetMessageRequest request, JsonElement raw)
    {
        var code = raw.GetProperty("code").GetInt32();
        var msg = raw.GetProperty("msg").GetString() ?? string.Empty;
        var data = raw.GetProperty("data");

        var messageElement = data.GetProperty("list").EnumerateArray().ElementAt(0);

        var msgId = new MessageId(messageElement.GetProperty("msgId").GetString() ?? string.Empty);
        var parentIdRaw = messageElement.GetProperty("parentId").GetString();
        MessageId? parentId = string.IsNullOrEmpty(parentIdRaw) ? null : new MessageId(parentIdRaw);
        var senderId = new UserId(int.Parse(messageElement.GetProperty("senderId").GetString() ?? string.Empty));
        var senderType = EnumUtils.ParseUserType(messageElement.GetProperty("senderType").GetString() ?? string.Empty);
        var senderNickname = messageElement.GetProperty("senderNickname").GetString() ?? string.Empty;
        var sender = new User(senderId, senderType, UserLevel.Unknown, senderNickname);
        var contentType = EnumUtils.ParseContentType(messageElement.GetProperty("contentType").GetString() ?? string.Empty);
        var content = ContentBuilderService.Instance.Build(contentType, messageElement.GetProperty("content"));
        var sendTime = DateTimeOffset.FromUnixTimeMilliseconds(messageElement.GetProperty("sendTime").GetInt64()).LocalDateTime;

        var commandName = messageElement.GetProperty("commandName").GetString();
        var commandId = messageElement.GetProperty("commandId").GetInt32();

        if (string.IsNullOrEmpty(commandName) || commandId == 0)
        {
            return new GetMessageResponse(code, msg, request, sender, new Message(msgId, sendTime, content, parentId));
        }

        return new GetMessageResponse(code, msg, request, sender, new CommandMessage(msgId, sendTime, content, parentId, new Command(commandId, commandName)));
    }
}