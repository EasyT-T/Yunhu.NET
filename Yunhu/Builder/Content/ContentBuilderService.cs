// <copyright file="ContentBuilderService.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public class ContentBuilderService
{
    private readonly Dictionary<ContentType, BuildContent> builders = [];

    private ContentBuilderService()
    {
        this.RegisterContent(new TextContentBuilder());
        this.RegisterContent(new ImageContentBuilder());
        this.RegisterContent(new MarkdownContentBuilder());
        this.RegisterContent(new HtmlContentBuilder());
        this.RegisterContent(new FileContentBuilder());
        this.RegisterContent(new VideoContentBuilder());
    }

    private delegate IContent BuildContent(JsonElement raw);

    public static ContentBuilderService Instance { get; } = new ContentBuilderService();

    public IContent Build(ContentType contentType, JsonElement raw)
    {
        if (!this.builders.TryGetValue(contentType, out var buildContent))
        {
            throw new InvalidOperationException("Content type not registered: " + contentType);
        }

        return buildContent(raw);
    }

    internal void RegisterContent<T>(IContentBuilder<T> builder)
        where T : IBuildableContent
    {
        this.builders[T.Type] = PackedBuilder;

        return;

        IContent PackedBuilder(JsonElement raw) => builder.Build(raw);
    }
}