// <copyright file="Button.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request.ChatContent;

using System.Text.Json.Serialization;

public record Button(string Text, IButtonAction Action)
{
    public ButtonTransfer ToTransfer()
    {
        var transfer = new ButtonTransfer
        {
            Text = this.Text,
            ActionType = (int)this.Action.Type,
        };

        if (this.Action.TryGetUrl(out var url))
        {
            transfer.Url = url;
        }

        if (this.Action.TryGetValue(out var value))
        {
            transfer.Value = value;
        }

        return transfer;
    }

    public class ButtonTransfer
    {
        [JsonPropertyName("text")]
        public required string Text { get; set; }

        [JsonPropertyName("actionType")]
        public required int ActionType { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
}