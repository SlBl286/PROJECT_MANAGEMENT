namespace PM.Presentation.User;

public record UserResponse(
    string Id,
    string Name,
    string Username,
    string Email,
    string PhoneNumber,
    string Avatar,
    int Role
);