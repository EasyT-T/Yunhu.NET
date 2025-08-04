// <copyright file="EventType.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

public enum EventType
{
     MessageReceiveNormal,
     MessageReceiveInstruction,
     BotFollowed,
     BotUnfollowed,
     GroupJoin,
     GroupLeave,
     ButtonReportInline,
     BotShortcutMenu,
}