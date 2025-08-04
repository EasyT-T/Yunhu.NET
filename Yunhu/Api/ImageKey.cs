// <copyright file="ImageKey.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using System.Diagnostics.CodeAnalysis;

public readonly struct ImageKey(string key) : IEquatable<ImageKey>
{
    public string Key { get; } = key;

    public static implicit operator ImageKey(string key)
    {
        return new ImageKey(key);
    }

    public static bool operator ==(ImageKey left, ImageKey right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ImageKey left, ImageKey right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return this.Key;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is ImageKey other && this.Key == other.Key;
    }

    public override int GetHashCode()
    {
        return this.Key.GetHashCode();
    }

    public bool Equals(ImageKey other)
    {
        return this.Key == other.Key;
    }
}