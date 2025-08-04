// <copyright file="IEventBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Event;

using Yunhu.Transfer;

public interface IEventBuilder<out T, in TE>
    where TE : ITransfer
{
    T Build(TE transfer);
}