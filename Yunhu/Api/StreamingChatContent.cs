// <copyright file="StreamingChatContent.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using System.Net;
using System.Net.Http.Headers;
using System.Text;

public class StreamingChatContent : HttpContent
{
    private readonly IEnumerator<string> messages;

    public StreamingChatContent(IEnumerator<string> messages, string contentType = "text/plain")
    {
        this.messages = messages;

        this.Headers.ContentType = new MediaTypeHeaderValue(contentType, "utf-8");
    }

    protected override void SerializeToStream(Stream stream, TransportContext? context, CancellationToken cancellationToken)
    {
        while (this.messages.MoveNext())
        {
            var message = this.messages.Current;
            var data = Encoding.UTF8.GetBytes(message);

            stream.Write(data);
            stream.Flush();
        }
    }

    protected override async Task SerializeToStreamAsync(Stream stream, TransportContext? context)
    {
        var endData = "\r\n"u8.ToArray();

        while (this.messages.MoveNext())
        {
            var message = this.messages.Current;
            var data = Encoding.UTF8.GetBytes(message);
            var lengthData = Encoding.UTF8.GetBytes(data.Length.ToString("X"));

            await stream.WriteAsync(lengthData);
            await stream.WriteAsync(endData);
            await stream.WriteAsync(data);
            await stream.WriteAsync(endData);

            await stream.FlushAsync();

            await Task.Yield();
        }

        await stream.WriteAsync("0"u8.ToArray());
        await stream.WriteAsync(endData);
        await stream.WriteAsync(endData);

        await stream.FlushAsync();
    }

    protected override bool TryComputeLength(out long length)
    {
        length = -1;
        return false;
    }
}