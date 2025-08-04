// <copyright file="YunhuRestClient.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu;

using System.Net;
using System.Text.Json;
using Serilog;
using Serilog.Core;
using Yunhu.Api;
using Yunhu.Builder.Event;
using Yunhu.Content;
using Yunhu.Event;
using Yunhu.Provider;
using Yunhu.Transfer;
using Yunhu.Util;

public class YunhuRestClient(YunhuConfig config)
{
    private ILogger logger = Logger.None;

    public event EventHandler<MessageEventContext>? NormalMessageReceived;

    public event EventHandler<CommandEventContext>? InstructionMessageReceived;

    public event EventHandler<ShortcutEventContext>? ShortcutMessageReceived;

    public YunhuConfig Config { get; } = config;

    public HttpListener HttpListener { get; } = new HttpListener();

    public IApiProvider ApiProvider { get; } = new YunhuBotProvider(config.Token);

    public void Start()
    {
        this.HttpListener.Prefixes.Add(this.Config.Address);
        this.HttpListener.Start();

        this.HttpListener.BeginGetContext(this.OnReceived, null);

        if (string.IsNullOrEmpty(this.Config.Token.Token))
        {
            this.logger.Warning("The bot token is empty. You will not be able to actively send requests to the Yunhu server.");
        }

        this.logger.Information("Yunhu.NET successfully started on {address}", this.Config.Address);
    }

    public void SetLogger(ILogger newLogger)
    {
        this.logger = newLogger;
    }

    private void OnReceived(IAsyncResult ar)
    {
        this.HttpListener.BeginGetContext(this.OnReceived, null);

        var context = this.HttpListener.EndGetContext(ar);
        var request = context.Request;
        var response = context.Response;

        this.logger.Debug("Handling new request from {address}", context.Request.RemoteEndPoint);

        if (request.ContentType?.Contains("application/json") != true)
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;

            return;
        }

        EventHeader eventHeader;
        JsonElement eventRawElement;

        try
        {
            var fullTransfer = JsonSerializer.Deserialize(request.InputStream, SourceGenerationContext.Default.FullTransfer);

            if (fullTransfer == null)
            {
                throw new JsonException("Invalid request");
            }

            eventHeader = EventBuilderService.Instance.Build<EventHeader, HeaderTransfer>(fullTransfer.Header);
            eventRawElement = fullTransfer.Event;
        }
        catch (Exception e)
        {
            this.logger.Debug(e, "Received a bad request from {address}", context.Request.RemoteEndPoint);

            return;
        }
        finally
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            context.Response.OutputStream.Close();
        }

        try
        {
            switch (eventHeader.EventType)
            {
                case EventType.MessageReceiveNormal:
                    var messageEventTransfer =
                        eventRawElement.Deserialize(SourceGenerationContext.Default.MessageEventTransfer)!;
                    var messageContext = EventBuilderService.Instance.Build<MessageEventContext, MessageEventTransfer>(messageEventTransfer);

                    this.NormalMessageReceived?.Invoke(this, messageContext);

                    break;
                case EventType.MessageReceiveInstruction:
                    var commandEventTransfer =
                        eventRawElement.Deserialize(SourceGenerationContext.Default.CommandEventTransfer)!;
                    var commandContext = EventBuilderService.Instance.Build<CommandEventContext, CommandEventTransfer>(commandEventTransfer);

                    this.InstructionMessageReceived?.Invoke(this, commandContext);

                    break;
                case EventType.BotFollowed:
                    break;
                case EventType.BotUnfollowed:
                    break;
                case EventType.GroupJoin:
                    break;
                case EventType.GroupLeave:
                    break;
                case EventType.ButtonReportInline:
                    break;
                case EventType.BotShortcutMenu:
                    var shortcutEventTransfer =
                        eventRawElement.Deserialize(SourceGenerationContext.Default.ShortcutEventTransfer)!;
                    var shortcutContext = EventBuilderService.Instance.Build<ShortcutEventContext, ShortcutEventTransfer>(shortcutEventTransfer);

                    this.ShortcutMessageReceived?.Invoke(this, shortcutContext);
                    break;
                default:
                    return;
            }
        }
        catch (Exception e)
        {
            this.logger.Error(e, "Encountered an exception while processing event.");
        }

        this.logger.Debug("Handled event type {eventType}", eventHeader.EventType);
    }
}