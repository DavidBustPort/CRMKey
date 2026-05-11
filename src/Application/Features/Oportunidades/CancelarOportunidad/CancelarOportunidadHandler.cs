using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Domain.Enums;

namespace Application.Features.Oportunidades.CancelarOportunidad
{
    public class CancelarOportunidadHandler(
        IOportunidadesRepository oportunidadesRepository,
        IUserContext userContext) : IApiRequestHandler<CancelarOportunidadCommand, bool>
    {
        public async Task<Result<bool>> Handle(CancelarOportunidadCommand request, CancellationToken ct)
        {
            if (userContext.Mode == SiteMode.siancentral)
                return Result<bool>.Failure(["Modo no permitido"]);

            var req = request with
            {
                SucursalId = userContext.SucursalId
            };

            bool result = await oportunidadesRepository.CancelarOportunidad(req, ct);
            return Result<bool>.Success(result);
        }
    }
}
