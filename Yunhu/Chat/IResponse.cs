// <copyright file="IResponse.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat;

public interface IResponse
{
    int Code { get; }

    string Message { get; }

    bool IsSuccess { get; }
}

public interface IResponse<out T> : IResponse
    where T : IRequest
{
    T Request { get; }
}