using Application.Common.Interfaces;
using Infrastructure.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService(IOptions<JwtOptions> options) : ITokenService
    {
        private readonly JwtOptions settings = options.Value;
        public string GenerateAccessToken(int userId, int? sucursalId, int? rikId)
        {
            var claims = new Claim[]
            {
                new(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new("UserId", userId.ToString()),
                new("SucursalId", sucursalId.ToString() ?? ""),
                new("RikId", rikId?.ToString() ?? ""),
                new(ClaimTypes.Name, userId.ToString())
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Key)),
                SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = settings.Issuer,
                Audience = settings.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(settings.ExpireMinutes),
                SigningCredentials = signingCredentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
