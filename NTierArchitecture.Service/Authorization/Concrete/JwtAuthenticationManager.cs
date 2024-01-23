using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic.FileIO;
using NTierArchitecture.API.Abstraction;
using NTierArchitecture.Core.DTOs.Authentication;
using NTierArchitecture.Service.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTierArchitecture.API.Concrete
{

    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly AppSettings _appSettings;

        public JwtAuthenticationManager(IOptions<AppSettings> appSettings)
        {
                _appSettings = appSettings.Value;
        }
        public AuthResponseDto Authenticate(string firstName, string password)
        {
            AuthResponseDto authResponse = new AuthResponseDto();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, firstName)
                    }),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                authResponse.Token = tokenHandler.WriteToken(token);

                return authResponse;
            }
            catch (Exception)
            {

                return authResponse;
            }
        }
    }
}
