namespace Yunhu.Test;

using System.Text.Json;
using Serilog;
using Serilog.Core;
using Yunhu.Api;
using Yunhu.Chat.Request;
using Yunhu.Chat.Request.ChatContent;
using Yunhu.Chat.Response;
using Yunhu.Event;
using Yunhu.Test.Util;

internal static class Program
{
    private static ILogger consoleLogger = Logger.None;

    public static async Task Main()
    {
        consoleLogger = new LoggerConfiguration().WriteTo.Console().MinimumLevel.Debug().CreateLogger();

        var config = await LoadConfigOrCreateNew();

        ILogger logger = new LoggerConfiguration().WriteTo.Console().MinimumLevel.Debug().CreateLogger();
        var client =
            new YunhuRestClient(new YunhuConfig(config.RemoteAddress, config.BotToken));

        client.SetLogger(logger);
        client.NormalMessageReceived += NormalMessageReceived;
        client.InstructionMessageReceived += CommandMessageReceived;
        client.ShortcutMessageReceived += ShortcutMessageReceived;

        client.Start();

        while (true)
        {
            if (!Console.KeyAvailable)
            {
                await Task.Delay(50);

                continue;
            }

            var input = Console.ReadLine() ?? string.Empty;

            if (input is not "stop" and not "close" and not "exit" and not "quit")
            {
                continue;
            }

            break;
        }
    }

    private static async ValueTask<Config> LoadConfigOrCreateNew()
    {
        const string configFile = "config.json";

        if (!File.Exists(configFile))
        {
            consoleLogger.Information("Creating a new config file...");

            return await CreateNewConfig(configFile);
        }

        var config = JsonSerializer.Deserialize(await File.ReadAllTextAsync("config.json"),
            SourceGenerationContext.Default.Config);

        if (config == null)
        {
            consoleLogger.Error("Unable to deserialize the exists config file. Creating a backup and a new config file...");

            File.Copy(configFile, configFile + ".bak", true);

            return await CreateNewConfig(configFile);
        }

        return config;
    }

    private static async ValueTask<Config> CreateNewConfig(string path)
    {
        var config = Config.Default;

        var jsonText = JsonSerializer.Serialize(config, SourceGenerationContext.Default.Config);

        await File.WriteAllTextAsync(path, jsonText);

        return config;
    }

    private static void NormalMessageReceived(object? sender, MessageEventContext context)
    {
        ArgumentNullException.ThrowIfNull(sender);

        consoleLogger.Information("Get normal message: {context}", context);

        if (context.Message.ParentId == null)
        {
            return;
        }

        var restClient = (YunhuRestClient)sender;
        IReceiver? receiver = context.Chat.ChatType switch
        {
            ChatType.Bot => new UserReceiver((UserId)context.Chat.ChatId),
            ChatType.Group => new GroupReceiver((GroupId)context.Chat.ChatId),
            _ => null,
        };

        if (receiver == null)
        {
            return;
        }

        var response =
            restClient.ApiProvider.Request<GetMessageRequest, GetMessageResponse>(
                new GetMessageRequest(receiver, context.Message.ParentId.Value));

        restClient.ApiProvider.Request<StreamingChatRequest, StreamingChatResponse>(
            new StreamingChatRequest(GetStreamingMessage(response.MessageResult), receiver));

        return;

        IEnumerator<string> GetStreamingMessage(Message message)
        {
            var content = $"Message you reference: {message}";

            foreach (var c in content)
            {
                yield return c.ToString();

                Thread.Sleep(10);
            }
        }
    }

    private static void CommandMessageReceived(object? sender, CommandEventContext context)
    {
        ArgumentNullException.ThrowIfNull(sender);

        consoleLogger.Information("Get command message: {context}", context);
    }

    private static void ShortcutMessageReceived(object? sender, ShortcutEventContext context)
    {
        ArgumentNullException.ThrowIfNull(sender);

        consoleLogger.Information("Get shortcut message: {context}", context);

        var restClient = (YunhuRestClient)sender;

        if (context.Chat.ChatType != ChatType.Group)
        {
            return;
        }

        var receiver = new GroupReceiver((GroupId)context.Chat.ChatId);
        var content = new TextChatContent("Hi! This is a simple text chat content with buttons.",
        [
            new Button("Click me to redirect", new RedirectButtonAction("https://www.yhchat.com/")),
            new Button("Click me to copy", new CopyButtonAction("Hello world")),
        ]);

        var response = restClient.ApiProvider.Request<ChatRequest, ChatResponse>(new ChatRequest(receiver, content));

        consoleLogger.Information(
            "Get response: (Code: {ResponseCode} Message: {ResponseMessage} Info: {Info} Success: {ResponseIsSuccess})",
            response.Code, response.Message, response.MessageInfo, response.IsSuccess);
    }
}