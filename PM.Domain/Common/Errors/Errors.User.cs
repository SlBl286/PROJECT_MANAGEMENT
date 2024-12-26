using ErrorOr;

namespace PM.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateUserName => Error.Conflict(code: "User.DuplicateUserName",description: " User already exists.");
        public static Error NotExist => Error.Conflict(code: "User.NotExist",description: " User does not exists.");

    }
}