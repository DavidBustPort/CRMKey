using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Common.Wrappers;

namespace Application.Features.Auth.RefreshToken
{
    public class RefreshTokenCommandHandler(
        IAuthRepository authRepository,
        ITokenService tokenService) : IApiRequestHandler<RefreshTokenCommand, TokenResponse>
    {
        public async Task<Result<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var existingToken = await authRepository.GetRefreshTokenAsync(request.UserId, request.RefreshToken);
            if (existingToken is null || !existingToken.IsActive)
            {
                return Result<TokenResponse>.Failure(["RefreshToken invalido"]);
            }

            await authRepository.InvalidateTokenAsync(request.UserId);

            string newToken = tokenService.GenerateAccessToken(request.UserId, request.SucursalId, request.RikId);
            string refreshToken = tokenService.GenerateRefreshToken();
            DateTime expiresIn = DateTime.UtcNow.AddHours(8);

            await authRepository.SaveTokenAsync(existingToken.UserId, refreshToken, expiresIn, existingToken.SucursalId ?? -1);

            return Result<TokenResponse>.Success(
                new TokenResponse(newToken, refreshToken, expiresIn),
                "Token generado correctamente"
            );
        }
    }
}
