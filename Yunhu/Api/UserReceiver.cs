// <copyright file="UserReceiver.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

public class UserReceiver(UserId id) : IReceiver
{
    public IAcceptableId Id { get; } = id;

    public ReceiveType Type => ReceiveType.User;
}