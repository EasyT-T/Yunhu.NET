// <copyright file="HtmlContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Content;

public record HtmlContent(string Html) : IBuildableContent
{
    public static ContentType Type => ContentType.Html;
}