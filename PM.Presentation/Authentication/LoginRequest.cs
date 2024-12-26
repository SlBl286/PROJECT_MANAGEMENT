namespace PM.Presentation.Authentication;

public record LoginRequest(
    string Username,
    string Password
);