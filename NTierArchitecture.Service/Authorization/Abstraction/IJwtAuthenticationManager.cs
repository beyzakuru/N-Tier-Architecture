using NTierArchitecture.Core.DTOs.Authentication;

namespace NTierArchitecture.API.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        AuthResponseDto Authenticate(string firstName, string password);
        int? ValidateJwtToken(string token);
    }
}
