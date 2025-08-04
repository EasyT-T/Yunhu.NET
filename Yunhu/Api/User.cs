// <copyright file="User.cs" company="ZiYueCommentary / EasyT_T">
// Copyright (c) ZiYueCommentary / EasyT_T. All rights reserved.
// </copyright>

namespace Yunhu.Api;

public class User
{
    internal User(UserId id, UserType type, UserLevel userLevel, string nickname)
    {
        this.Id = id;
        this.Type = type;
        this.Level = userLevel;
        this.Nickname = nickname;
    }

    public UserId Id { get; }

    public UserType Type { get; }

    public UserLevel Level { get; }

    public string Nickname { get; }

    public override string ToString()
    {
        return $"User: ID({this.Id}) Type({this.Type})";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not User user)
        {
            return false;
        }

        return user.Id == this.Id;
    }

    public override int GetHashCode()
    {
        return this.Id.GetHashCode();
    }
}