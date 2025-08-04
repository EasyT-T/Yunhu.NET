// <copyright file="HtmlContentBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public class HtmlContentBuilder : IContentBuilder<HtmlContent>
{
    public HtmlContent Build(JsonElement raw)
    {
        var html = raw.GetProperty("text").GetString()!;
        return new HtmlContent(html);
    }
}