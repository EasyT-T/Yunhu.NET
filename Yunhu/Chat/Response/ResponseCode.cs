// <copyright file="ResponseCode.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Response;

public enum ResponseCode
{
    Success = 1,
    InvalidParameter = 1002,
    Unauthorized = 1003,
    BotBanned = 1004,
    ChatBanned = 1005,
    FrequencyLimit = 1007,
}