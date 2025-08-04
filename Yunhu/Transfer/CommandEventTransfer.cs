// <copyright file="CommandEventTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

public class CommandEventTransfer : ITransfer
{
    public required UserTransfer Sender { get; set; }

    public required ChatTransfer Chat { get; set; }

    public required CommandMessageTransfer Message { get; set; }
}