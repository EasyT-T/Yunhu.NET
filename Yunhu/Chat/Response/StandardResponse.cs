// <copyright file="StandardResponse.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Response;

public class StandardResponse<T> : IResponse<T>
    where T : IRequest
{
    protected StandardResponse(int code, string message, T request)
    {
        this.Code = code;
        this.Message = message;
        this.IsSuccess = code == (int)ResponseCode.Success;
        this.Request = request;
    }

    public int Code { get; }

    public string Message { get; }

    public bool IsSuccess { get; }

    public T Request { get; }
}