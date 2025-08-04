// <copyright file="YunhuBotProvider.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Provider;

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Yunhu.Api;
using Yunhu.Builder.Response;
using Yunhu.Chat;

public class YunhuBotProvider(BotToken token) : IApiProvider
{
    private const string ApiUrl = "https://chat-go.jwzhd.com/open-apis/v1/";

    private readonly HttpClient httpClient = new HttpClient
    {
        BaseAddress = new Uri(ApiUrl),
    };

    public TResponse Request<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest
        where TResponse : IResponse<TRequest>
    {
        var separator = request.ApiUrl.Contains('?') ? "&" : "?";

        var requestUri = $"{request.ApiUrl}{separator}token={token.ToString()}";

        var message = new HttpRequestMessage(request.Method, requestUri)
        {
            Content = request.Content,
        };

        var response = this.httpClient.Send(message);
        response.EnsureSuccessStatusCode();

        var rawJson = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        using var document = JsonDocument.Parse(rawJson);

        return ResponseBuilderService.Instance.Build<TRequest, TResponse>(request, document.RootElement);
    }

    public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest
        where TResponse : IResponse<TRequest>
    {
        var requestUri = $"{request.ApiUrl}?token={token.ToString()}";
        HttpContent content = new StringContent(string.Empty, Encoding.UTF8, "application/json");

        var message = new HttpRequestMessage(request.Method, requestUri)
        {
            Content = content,
        };

        var response = await this.httpClient.SendAsync(message);
        response.EnsureSuccessStatusCode();

        var rawJson = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(rawJson);

        return ResponseBuilderService.Instance.Build<TRequest, TResponse>(request, document.RootElement);
    }
}