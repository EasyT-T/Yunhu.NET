// <copyright file="UserBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Api;
using Yunhu.Transfer;
using Yunhu.Util;

public class UserBuilder : IEventBuilder<User, UserTransfer>
{
    public User Build(UserTransfer transfer)
    {
        var id = new UserId(int.Parse(transfer.SenderId));
        var type = EnumUtils.ParseUserType(transfer.SenderType);
        var userLevel = EnumUtils.ParseUserLevel(transfer.SenderUserLevel);
        var nickname = transfer.SenderNickname;

        return new User(id, type, userLevel, nickname);
    }
}