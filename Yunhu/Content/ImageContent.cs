// <copyright file="ImageContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Content;

public record ImageContent(string? Url, string Name, int Width, int Height, string Etag)
    : IBuildableContent
{
    public static ContentType Type => ContentType.Image;
}