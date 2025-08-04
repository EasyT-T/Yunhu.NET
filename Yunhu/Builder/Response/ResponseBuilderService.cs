// <copyright file="ResponseBuilderService.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Response;

using System.Text.Json;
using Yunhu.Chat;

public class ResponseBuilderService
{
    private readonly Dictionary<Type, BuildResponse> builders = [];

    private ResponseBuilderService()
    {
        this.Register(new ChatResponseBuilder());
        this.Register(new GetMessageResponseBuilder());
        this.Register(new UploadImageResponseBuilder());
        this.Register(new StreamingChatResponseBuilder());
    }

    private delegate IResponse BuildResponse(IRequest request, JsonElement raw);

    public static ResponseBuilderService Instance { get; } = new ResponseBuilderService();

    public TResponse Build<TRequest, TResponse>(TRequest request, JsonElement raw)
        where TRequest : IRequest
        where TResponse : IResponse<TRequest>
    {
        if (!this.builders.TryGetValue(typeof(TResponse), out var buildContent))
        {
            throw new InvalidOperationException("Response type not registered: " + nameof(TResponse));
        }

        return (TResponse)buildContent(request, raw);
    }

    internal void Register<TRequest, TResponse>(IResponseBuilder<TRequest, TResponse> builder)
        where TRequest : IRequest
        where TResponse : IResponse<TRequest>
    {
        this.builders[typeof(TResponse)] = PackedBuilder;

        return;

        IResponse PackedBuilder(IRequest request, JsonElement raw) => builder.Build((TRequest)request, raw);
    }
}