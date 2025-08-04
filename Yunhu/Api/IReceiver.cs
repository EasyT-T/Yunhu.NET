// <copyright file="IReceiver.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

public interface IReceiver
{
    IAcceptableId Id { get; }

    ReceiveType Type { get; }
}