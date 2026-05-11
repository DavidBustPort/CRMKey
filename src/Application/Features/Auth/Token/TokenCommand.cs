using Application.Common.DTOs;
using Application.Common.Interfaces;

namespace Application.Features.Auth.Token
{
    public record TokenCommand(
        int UserId,
        int? SucursalId = null,
        int? RikId = null) : IApiRequest<TokenResponse>;
}
