// <copyright file="IBuildableContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Content;

public interface IBuildableContent : IContent
{
    static abstract ContentType Type { get; }
}