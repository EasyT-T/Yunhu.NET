// <copyright file="GroupId.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using System.Diagnostics.CodeAnalysis;

public readonly struct GroupId(int id) : IAcceptableId, IEquatable<GroupId>
{
    public int Id { get; } = id;

    public static bool operator ==(GroupId left, GroupId right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(GroupId left, GroupId right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return this.Id.ToString();
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is GroupId other && this.Id == other.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }

    public bool Equals(GroupId other)
    {
        return this.Id == other.Id;
    }
}