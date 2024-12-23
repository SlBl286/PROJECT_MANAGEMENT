using PM.Domain.Common.Models;
using PM.Domain.UserAggregate.Enums;
using PM.Domain.UserAggregate.ValueObjects;

namespace PM.Domain.UserAggregate;

public sealed class User : AggregatetRoot<UserId, Guid>
{
    public string Name { get; private set; }
    public string Username { get; private set; }
    public string? Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Avatar { get; private set; }
    public string HashedPassword { get; private set; }
    public UserRole Role { get; private set; }
    public string Salt { get; private set; }
    public RefreshToken RefreshToken { get; private set; }
    private User(UserId id,
                 string name,
                 string username,
                 string? email,
                 string? phoneNumber,
                 string? avatar,
                 string hashedPassword,
                 UserRole role,
                 string salt,
                 RefreshToken refreshToken) : base(id)
    {
        Name = name;
        Username = username;
        Email = email;
        PhoneNumber = phoneNumber;
        Avatar = avatar;
        HashedPassword = hashedPassword;
        Role = role;
        Salt = salt;
        RefreshToken = refreshToken;
    }

    public static User Create(UserId id,
                            string name,
                              string username,
                              string? email,
                              string? phoneNumber,
                              string? avatar,
                              string hashedPassword,
                              UserRole role,
                              string salt,
                              RefreshToken refreshToken)
    {
        return new User(id, name, username, email, phoneNumber, avatar, hashedPassword,role, salt, refreshToken);
    }

#pragma warning disable CS0618
    private User() { }
#pragma warning restore CS0618
}

