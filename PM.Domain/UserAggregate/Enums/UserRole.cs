namespace PM.Domain.UserAggregate.Enums;
public enum  UserRole
{
    Admin ,
    User
}

static class UserRoleExtensions
{
    public static string GetStringCode(this UserRole role)
    {
        return role switch
        {
            UserRole.Admin => "Admin",
            UserRole.User => "User",
            _ => throw new ArgumentOutOfRangeException("userRole"),
        };
    }
}