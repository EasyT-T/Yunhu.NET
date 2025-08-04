// <copyright file="UserTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

public class UserTransfer : ITransfer
{
    public required string SenderId { get; set; }

    public required string SenderType { get; set; }

    public required string SenderUserLevel { get; set; }

    public required string SenderNickname { get; set; }
}