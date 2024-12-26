namespace PM.Presentation.Authentication;

public record RegisterRequest(
    string FirstName,
    string LastName,
    string Username,
    string Password,
    string? Email,
    string? PhoneNumber,
    string? Address,
    DateTime? BirthDay
);