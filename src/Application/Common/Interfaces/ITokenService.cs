namespace Application.Common.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(int userId, int? sucursalId, int? rikId);
        string GenerateRefreshToken();
    }
}
