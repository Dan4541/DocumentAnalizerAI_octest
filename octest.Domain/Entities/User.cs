using octest.Domain.Constants;

namespace octest.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? LastLoginAt { get; private set; }
    public List<string> Roles { get; private set; }
    public string? RefreshToken { get; private set; }
    public DateTime? RefreshTokenExpiryTime { get; private set; }

    private User()
    {
        Roles = new List<string>();
    }

    public static User Create(string email, string passwordHash,
        string firstName, string lastName, bool isAdmin = false)
    {
        if (string.IsNullOrWhiteSpace(email))
        throw new ArgumentException("Email cannot be empty", nameof(email));

        if (string.IsNullOrWhiteSpace(passwordHash))
        throw new ArgumentException("Password hash cannot be empty", nameof(passwordHash));

        var roles = new List<string> { UserRoles.User };

        if (isAdmin)
        {
            roles.Add(UserRoles.Admin);
        }

        return new User
        {
            Id = Guid.NewGuid(),
            Email = email.ToLowerInvariant(),
            PasswordHash = passwordHash,
            FirstName = firstName,
            LastName = lastName,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            Roles = new List<string>()
        };
    }

    public void UpdateLastLogin()
    {
        LastLoginAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void AddRole(string role)
    {
        if (UserRoles.IsValidRole(role))
            throw new ArgumentException("Role must be a valid role", nameof(role));

        if (!Roles.Contains(role))
        {
            Roles.Add(role);
        }
    }

    public void RemoveRole(string role)
    {
        if (role == UserRoles.User && this.Roles.Count == 1)
            throw new ArgumentException("Role must be a valid role", nameof(role));

        Roles.Remove(role);
    }

    public bool HasRole(string role)
    {
        return Roles.Contains(role);
    }

    public bool IsAdmin()
    {
        return Roles.Contains(UserRoles.Admin);
    }

    public void SetRefreshToken(string refreshToken, DateTime expiryTime)
    {
        RefreshToken = refreshToken;
        RefreshTokenExpiryTime = expiryTime;
    }

    public void ClearRefreshToken()
    {
        RefreshToken = null;
        RefreshTokenExpiryTime = null;
    }

    public bool IsRefreshTokenValid()
    {
        return !string.IsNullOrWhiteSpace(RefreshToken) &&
               RefreshTokenExpiryTime.HasValue &&
               RefreshTokenExpiryTime.Value > DateTime.UtcNow;
    }
}
