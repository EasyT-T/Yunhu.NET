// <copyright file="MarkdownContentBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public class MarkdownContentBuilder : IContentBuilder<MarkdownContent>
{
    public MarkdownContent Build(JsonElement raw)
    {
        var markdown = raw.GetProperty("text").GetString()!;
        return new MarkdownContent(markdown);
    }
}