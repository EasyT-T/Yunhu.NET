// <copyright file="VideoContentBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public class VideoContentBuilder : IContentBuilder<VideoContent>
{
    public VideoContent Build(JsonElement raw)
    {
        var url = raw.GetProperty("videoUrl").GetString() ?? string.Empty;
        var duration = TimeSpan.FromSeconds(raw.GetProperty("videoDuration").GetInt64());

        return new VideoContent(url, duration);
    }
}