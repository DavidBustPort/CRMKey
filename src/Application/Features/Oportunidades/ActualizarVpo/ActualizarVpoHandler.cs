using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Domain.Enums;

namespace Application.Features.Oportunidades.ActualizarVpo
{
    public class ActualizarVpoHandler(
        IOportunidadesRepository oportunidadesRepository,
        IUserContext userContext) : IApiRequestHandler<ActualizarVpoCommand, bool>
    {
        public async Task<Result<bool>> Handle(ActualizarVpoCommand request, CancellationToken ct)
        {
            if (userContext.Mode == SiteMode.siancentral)
                return Result<bool>.Failure(["Modo no permitido"]);

            var req = request with
            {
                SucursalId = userContext.SucursalId
            };

            bool result = await oportunidadesRepository.ActualizarVpo(req, ct);
            return Result<bool>.Success(result);
        }
    }
}
