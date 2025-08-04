// <copyright file="VideoKey.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using System.Diagnostics.CodeAnalysis;

public readonly struct VideoKey(string key) : IEquatable<VideoKey>
{
    public string Key { get; } = key;

    public static implicit operator VideoKey(string key)
    {
        return new VideoKey(key);
    }

    public static bool operator ==(VideoKey left, VideoKey right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(VideoKey left, VideoKey right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return this.Key;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is VideoKey other && this.Key == other.Key;
    }

    public override int GetHashCode()
    {
        return this.Key.GetHashCode();
    }

    public bool Equals(VideoKey other)
    {
        return this.Key == other.Key;
    }
}