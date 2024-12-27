namespace PM.Presentation.Authentication;

public record RegisterRequest(
    string Name,
    string Username,
    string Password,
    string? Email,
    string? PhoneNumber,
    string? Avatar
);