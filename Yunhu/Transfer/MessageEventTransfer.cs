// <copyright file="MessageEventTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

public class MessageEventTransfer : ITransfer
{
    public required UserTransfer Sender { get; set; }

    public required ChatTransfer Chat { get; set; }

    public required MessageTransfer Message { get; set; }
}