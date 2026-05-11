using Application.Common.Interfaces;
using Application.Features.Auth;
using Dapper;
using Domain.Entities.Sianwebcentral;
using Domain.Enums;

namespace Infrastructure.Repositories
{
    public class AuthRepository(ISqlConnectionFactory factory) : IAuthRepository
    {
        public async Task<RefreshTokens?> GetRefreshTokenAsync(int userId, string refreshToken)
        {
            using var db = await factory.CreateConnection(SiteMode.sianwebcentral);
            const string query = @"
                SELECT * 
                FROM RefreshTokens
                WHERE Token = @refreshToken
                    AND IsActive
                    AND ExpiryDate > @now
                    AND UserId = @userId";

            return await db.QueryFirstOrDefaultAsync<RefreshTokens>(query, new
            {
                refreshToken,
                now = DateTime.UtcNow,
                userId
            });
        }

        public async Task InvalidateAllUsersTokenAsync(int userId)
        {
            using var db = await factory.CreateConnection(SiteMode.sianwebcentral);
            const string query = @"
                UPDATE RefreshTokens
                SET IsActive = 0
                WHERE UserId = @userId AND IsActive = 1";

            await db.ExecuteAsync(query, new { userId });
        }

        public async Task InvalidateTokenAsync(int userId)
        {
            using var db = await factory.CreateConnection(SiteMode.sianwebcentral);
            const string query = @"
                UPDATE RefreshTokens
                SET IsActive = 0
                WHERE UserId = @userId AND IsActive = 1";

            await db.ExecuteAsync(query, new { userId });
        }

        public async Task SaveTokenAsync(int userId, string refreshToken, DateTime expiresIn, int sucursalId)
        {
            using var db = await factory.CreateConnection(SiteMode.sianwebcentral);
            const string query = @"
                INSERT INTO RefreshTokens (UserId, SucursalId, Token, CreateAt, ExpiryDate, IsActive)
                VALUES (@userId, @sucursalId, @refreshToken, @createAt, @expiresIn, 1)";

            await db.ExecuteAsync(query, new
            {
                userId,
                sucursalId,
                refreshToken,
                createAt = DateTime.UtcNow,
                expiresIn
            });
        }
    }
}
