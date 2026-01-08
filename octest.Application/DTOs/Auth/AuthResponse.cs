namespace octest.Application.DTOs.Auth;

public record AuthResponse(
    Guid UserId,
    string Email,
    string FirstName,
    string LastName,
    string Token,
    string RefreshToken,
    DateTime ExpiresAt,
    List<string> Roles
);

/*
public record AuthResponse
{
    public Guid UserId { get; init; }
    public string Email { get; init; } = string.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Token { get; init; } = string.Empty;
    public DateTime ExpiresAt { get; init; }
    public List<string> Roles { get; init; } = new();
}
*/