// <copyright file="BotToken.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

using System.Diagnostics.CodeAnalysis;

public readonly struct BotToken(string token) : IEquatable<BotToken>
{
    public string Token { get; } = token;

    public static implicit operator BotToken(string token)
    {
        return new BotToken(token);
    }

    public static bool operator ==(BotToken left, BotToken right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(BotToken left, BotToken right)
    {
        return !(left == right);
    }

    public override string ToString()
    {
        return this.Token;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        return obj is BotToken other && this.Token == other.Token;
    }

    public override int GetHashCode()
    {
        return this.Token.GetHashCode();
    }

    public bool Equals(BotToken other)
    {
        return this.Token == other.Token;
    }
}