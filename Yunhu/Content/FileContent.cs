// <copyright file="FileContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Content;

public record FileContent(string Url, string Name, int Size, string ETag)
    : IBuildableContent
{
    public static ContentType Type => ContentType.File;
}