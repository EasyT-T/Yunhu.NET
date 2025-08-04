// <copyright file="MessageId.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using System.Diagnostics.CodeAnalysis;

public readonly struct MessageId(string id) : IEquatable<MessageId>
{
    public string Id { get; } = id;

    public static bool operator ==(MessageId left, MessageId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(MessageId left, MessageId right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return this.Id;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is MessageId other && this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public bool Equals(MessageId other)
    {
        return this.Id == other.Id;
    }
}