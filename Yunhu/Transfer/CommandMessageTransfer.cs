// <copyright file="CommandMessageTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

public class CommandMessageTransfer : MessageTransfer
{
    public required int CommandId { get; set; }

    public required string CommandName { get; set; }
}