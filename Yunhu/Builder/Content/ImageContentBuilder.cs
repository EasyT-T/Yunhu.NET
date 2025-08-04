// <copyright file="ImageContentBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public class ImageContentBuilder : IContentBuilder<ImageContent>
{
    public ImageContent Build(JsonElement raw)
    {
        string? url = null;

        if (raw.TryGetProperty("imageUrl", out var urlProperty))
        {
            url = urlProperty.GetString();
        }

        var name = raw.GetProperty("imageName").GetString() ?? string.Empty;
        var width = raw.GetProperty("imageWidth").GetInt32();
        var height = raw.GetProperty("imageHeight").GetInt32();
        var etag = raw.GetProperty("etag").GetString() ?? string.Empty;
        return new ImageContent(url, name, width, height, etag);
    }
}