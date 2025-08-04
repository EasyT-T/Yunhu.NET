// <copyright file="IResponseBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Response;

using System.Text.Json;
using Yunhu.Chat;

public interface IResponseBuilder<in TRequest, out TResponse>
    where TRequest : IRequest
    where TResponse : IResponse<TRequest>
{
    TResponse Build(TRequest request, JsonElement raw);
}