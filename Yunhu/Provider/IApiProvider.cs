// <copyright file="IApiProvider.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Provider;

using Yunhu.Chat;

public interface IApiProvider
{
    TResponse Request<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest
        where TResponse : IResponse<TRequest>;

    Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest
        where TResponse : IResponse<TRequest>;
}