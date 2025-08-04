// <copyright file="TextContentBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public class TextContentBuilder : IContentBuilder<TextContent>
{
    public TextContent Build(JsonElement raw)
    {
        return new TextContent(raw.GetProperty("text").GetString() ?? string.Empty);
    }
}