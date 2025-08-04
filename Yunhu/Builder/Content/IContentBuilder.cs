// <copyright file="IContentBuilder.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Builder.Content;

using System.Text.Json;
using Yunhu.Content;

public interface IContentBuilder<out T>
    where T : IBuildableContent
{
    T Build(JsonElement raw);
}