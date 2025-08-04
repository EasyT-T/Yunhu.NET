// <copyright file="IRequest.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat;

public interface IRequest
{
    string ApiUrl { get; }

    HttpMethod Method { get; }

    HttpContent? Content { get; }
}