// <copyright file="UploadImageRequest.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Chat.Request;

public class UploadImageRequest(string imagePath) : IRequest
{
    public string ApiUrl => "image/upload";

    public HttpMethod Method { get; } = HttpMethod.Post;

    public HttpContent Content => new MultipartFormDataContent()
    {
        { new StreamContent(this.GetImage()), "image" },
    };

    private FileStream GetImage()
    {
        if (!File.Exists(imagePath))
        {
            throw new FileNotFoundException($"File {imagePath} not found");
        }

        return File.OpenRead(imagePath);
    }
}