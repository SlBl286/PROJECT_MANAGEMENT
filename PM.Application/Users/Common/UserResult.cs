
using PM.Domain.UserAggregate;

namespace PM.Application.Users.Common;

public record UserResult(
    User User
);


public record UsersResult(
    List<UserResult> Users
);