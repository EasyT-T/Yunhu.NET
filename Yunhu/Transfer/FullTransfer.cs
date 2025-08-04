// <copyright file="FullTransfer.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Transfer;

using System.Text.Json;

public class FullTransfer : ITransfer
{
    public required string Version { get; set; }

    public required HeaderTransfer Header { get; set; }

    public required JsonElement Event { get; set; }
}