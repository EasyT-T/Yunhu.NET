// <copyright file="ChatTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

public class ChatTransfer : ITransfer
{
    public required string ChatId { get; set; }

    public required string ChatType { get; set; }
}