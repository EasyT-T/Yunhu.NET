// <copyright file="SourceGenerationContext.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Util;

using System.Text.Json;
using System.Text.Json.Serialization;
using Yunhu.Chat.Request;
using Yunhu.Chat.Request.ChatContent;
using Yunhu.Transfer;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(UserTransfer))]
[JsonSerializable(typeof(MessageTransfer))]
[JsonSerializable(typeof(MessageEventTransfer))]
[JsonSerializable(typeof(CommandMessageTransfer))]
[JsonSerializable(typeof(CommandEventTransfer))]
[JsonSerializable(typeof(ShortcutEventTransfer))]
[JsonSerializable(typeof(HeaderTransfer))]
[JsonSerializable(typeof(FullTransfer))]
[JsonSerializable(typeof(Button.ButtonTransfer))]
[JsonSerializable(typeof(FileChatContent.FileChatContentTransfer))]
[JsonSerializable(typeof(ImageChatContent.ImageChatContentTransfer))]
[JsonSerializable(typeof(MarkdownChatContent.MarkdownChatContentTransfer))]
[JsonSerializable(typeof(TextChatContent.TextChatContentTransfer))]
[JsonSerializable(typeof(VideoChatContent.VideoChatContentTransfer))]
[JsonSerializable(typeof(ChatRequest.IChatContentTransfer))]
[JsonSerializable(typeof(ChatRequest.ChatRequestTransfer))]
internal partial class SourceGenerationContext : JsonSerializerContext;