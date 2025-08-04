// <copyright file="UploadImageResponse.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Response;

using Yunhu.Api;
using Yunhu.Chat.Request;

public class UploadImageResponse : StandardResponse<UploadImageRequest>
{
    internal UploadImageResponse(int code, string message, UploadImageRequest request, ImageKey imageKey)
        : base(code, message, request)
    {
        this.ImageKey = imageKey;
    }

    public ImageKey ImageKey { get; }
}