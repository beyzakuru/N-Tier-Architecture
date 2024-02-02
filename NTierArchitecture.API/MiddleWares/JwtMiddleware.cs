using NTierArchitecture.API.Abstraction;
using NTierArchitecture.Core.Services;

namespace NTierArchitecture.API.MiddleWares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IPassengerService passengerService, IJwtAuthenticationManager iJwtAuthenticationManager)
        {
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            string token = null;

            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                var parts = authorizationHeader.Split(" ");
                if (parts.Length > 1)
                {
                    token = parts[parts.Length - 1];
                }
            }

            var passengerId = iJwtAuthenticationManager.ValidateJwtToken(token);
            if (passengerId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = passengerService.GetById(passengerId.Value).Result;
            }

            await _next(context);
        }
    }
}
