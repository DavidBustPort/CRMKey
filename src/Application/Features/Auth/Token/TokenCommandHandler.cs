using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Common.Wrappers;

namespace Application.Features.Auth.Token
{
    public class TokenCommandHandler(
        IAuthRepository authRepository,
        ITokenService tokenService) : IApiRequestHandler<TokenCommand, TokenResponse>
    {
        public async Task<Result<TokenResponse>> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            await authRepository.InvalidateAllUsersTokenAsync(request.UserId);

            string token = tokenService.GenerateAccessToken(request.UserId, request.SucursalId, request.RikId);
            string refreshToken = tokenService.GenerateRefreshToken();

            DateTime expiresIn = DateTime.UtcNow.AddHours(8);
            await authRepository.SaveTokenAsync(
                request.UserId,
                refreshToken,
                expiresIn,
                request.SucursalId ?? -1);

            return Result<TokenResponse>.Success(
                new TokenResponse(token, refreshToken, expiresIn)
                , "Token generado correctamente");
        }
    }
}
