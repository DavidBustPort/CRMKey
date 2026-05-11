using Domain.Entities.Sianwebcentral;

namespace Application.Features.Auth
{
    public interface IAuthRepository
    {
        Task InvalidateAllUsersTokenAsync(int userId);
        Task SaveTokenAsync(
            int userId,
            string refreshToken,
            DateTime expiresIn,
            int sucursalId);

        Task<RefreshTokens?> GetRefreshTokenAsync(int userId, string refreshToken);
        Task InvalidateTokenAsync(int userId);
    }
}
