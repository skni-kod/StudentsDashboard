namespace StudentsDashboard.Application.Contracts.Authentication;

public record VerifyEmailRequest(
    string Email,
    string Token
    );