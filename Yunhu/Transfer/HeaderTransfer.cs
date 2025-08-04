// <copyright file="HeaderTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

public class HeaderTransfer : ITransfer
{
    public required string EventId { get; set; }

    public required long EventTime { get; set; }

    public required string EventType { get; set; }
}