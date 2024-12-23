using ErrorOr;

namespace PM.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(code: "Auth.InvalidCred",description: " Invalid Credentials.");
        public static Error InvalidRefreshToken => Error.Conflict(code: "Auth.InvalidRefreshToken",description: " Invalid Refresh Token.");

    }
}