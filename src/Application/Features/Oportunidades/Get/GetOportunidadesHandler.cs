using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Domain.Enums;

namespace Application.Features.Oportunidades.Get
{
    public class GetOportunidadesHandler(
        IOportunidadesRepository oportunidadesRepository,
        IUserContext userContext) : IApiRequestHandler<GetOportunidadesQuery, OportunidadesResponse>
    {
        public async Task<Result<OportunidadesResponse>> Handle(GetOportunidadesQuery request, CancellationToken cancellationToken)
        {
            if (userContext.Mode == SiteMode.siancentral)
                return Result<OportunidadesResponse>.Failure(["Modo no permitido"]);

            var req = request with
            {
                FilterRik = request.IsUserManager ? request.FilterRik : userContext.RikId,
                SucursalId = userContext.SucursalId,
            };

            var oportunidadesResult = await oportunidadesRepository.GetAsync(req);
            if (oportunidadesResult is null || oportunidadesResult.Count == 0)
            {
                return Result<OportunidadesResponse>.Failure(["No se encontraron oportunidades"]);
            }

            var response = OportunidadesMapper.ToResponse(oportunidadesResult);
            return Result<OportunidadesResponse>.Success(response);
        }
    }
}
