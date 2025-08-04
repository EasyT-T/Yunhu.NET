// <copyright file="GroupReceiver.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

public class GroupReceiver(GroupId groupId) : IReceiver
{
    public IAcceptableId Id { get; } = groupId;

    public ReceiveType Type => ReceiveType.Group;
}