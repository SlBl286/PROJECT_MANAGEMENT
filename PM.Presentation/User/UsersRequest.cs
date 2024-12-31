namespace PM.Presentation.User;

public record UsersRequest(
    bool IncludeMe,
    Guid? ProjectId = null
);