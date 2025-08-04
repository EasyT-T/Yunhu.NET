// <copyright file="MessageTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

using System.Text.Json;

public class MessageTransfer : ITransfer
{
    public required string MsgId { get; set; }

    public string? ParentId { get; set; }

    public required long SendTime { get; set; }

    public required string ContentType { get; set; }

    public required JsonElement Content { get; set; }
}