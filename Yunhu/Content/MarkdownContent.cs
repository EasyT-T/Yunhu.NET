// <copyright file="MarkdownContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Content;

public record MarkdownContent(string Markdown) : IBuildableContent
{
    public static ContentType Type => ContentType.Markdown;
}