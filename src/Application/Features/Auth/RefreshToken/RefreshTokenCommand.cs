using Application.Common.DTOs;
using Application.Common.Interfaces;

namespace Application.Features.Auth.RefreshToken
{
    public record RefreshTokenCommand(
        int UserId,
        string RefreshToken,
        int? SucursalId = null,
        int? RikId = null) : IApiRequest<TokenResponse>;
}
