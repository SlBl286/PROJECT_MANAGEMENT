namespace PM.Presentation.User;

public record UserResponse(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string Email,
    string PhoneNumber
);