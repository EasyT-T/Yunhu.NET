// <copyright file="TextContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Content;

public record TextContent(string Text) : IBuildableContent
{
    public static ContentType Type => ContentType.Text;
}