// <copyright file="FileContentBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public class FileContentBuilder : IContentBuilder<FileContent>
{
    public FileContent Build(JsonElement raw)
    {
        var url = raw.GetProperty("fileUrl").GetString() ?? string.Empty;
        var name = raw.GetProperty("fileName").GetString() ?? string.Empty;
        var size = raw.GetProperty("fileSize").GetInt32();
        var etag = raw.GetProperty("etag").GetString() ?? string.Empty;
        return new FileContent(url, name, size, etag);
    }
}