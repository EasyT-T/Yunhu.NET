// <copyright file="FileKey.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using System.Diagnostics.CodeAnalysis;

public readonly struct FileKey(string key) : IEquatable<FileKey>
{
    public string Key { get; } = key;

    public static implicit operator FileKey(string key)
    {
        return new FileKey(key);
    }

    public static bool operator ==(FileKey left, FileKey right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(FileKey left, FileKey right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return this.Key;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is FileKey other && this.Key == other.Key;
    }

    public override int GetHashCode()
    {
        return this.Key.GetHashCode();
    }

    public bool Equals(FileKey other)
    {
        return this.Key == other.Key;
    }
}