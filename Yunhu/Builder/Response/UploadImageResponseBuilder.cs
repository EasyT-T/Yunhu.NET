// <copyright file="UploadImageResponseBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Response;

using System.Text.Json;
using Yunhu.Api;
using Yunhu.Chat.Request;
using Yunhu.Chat.Response;

public class UploadImageResponseBuilder : IResponseBuilder<UploadImageRequest, UploadImageResponse>
{
    public UploadImageResponse Build(UploadImageRequest request, JsonElement raw)
    {
        var code = raw.GetProperty("code").GetInt32();
        var msg = raw.GetProperty("msg").GetString() ?? string.Empty;
        var data = raw.GetProperty("data");

        var imageKey = new ImageKey(raw.GetProperty("imageKey").GetString() ?? string.Empty);

        return new UploadImageResponse(code, msg, request, imageKey);
    }
}