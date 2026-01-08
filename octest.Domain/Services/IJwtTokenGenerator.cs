using octest.Domain.Entities;

namespace octest.Domain.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
    Guid? ValidateToken(string token);
    string GenerateRefreshToken();
}
