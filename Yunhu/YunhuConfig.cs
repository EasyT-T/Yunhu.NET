// <copyright file="YunhuConfig.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu;

using Yunhu.Api;

[Serializable]
public record YunhuConfig(string Address, BotToken Token);