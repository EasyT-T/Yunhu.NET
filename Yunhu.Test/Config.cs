namespace Yunhu.Test;

public class Config(bool isDebug, string remoteAddress, string botToken)
{
    public static Config Default { get; } = new Config(false, "http://*:12345/", string.Empty);

    public bool IsDebug { get; set; } = isDebug;
    public string RemoteAddress { get; set; } = remoteAddress;
    public string BotToken { get; set; } = botToken;
}