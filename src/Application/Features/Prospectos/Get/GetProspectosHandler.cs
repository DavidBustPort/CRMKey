using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Domain.Enums;

namespace Application.Features.Prospectos.Get
{
    public class GetProspectosHandler(
        IProspectosRepository prospectosRepository,
        IUserContext userContext) : IApiRequestHandler<GetProspectosQuery, ProspectosResponse>
    {
        public async Task<Result<ProspectosResponse>> Handle(GetProspectosQuery request, CancellationToken cancellationToken)
        {
            if (userContext.Mode == SiteMode.siancentral)
                return Result<ProspectosResponse>.Failure(["Modo no permitido"]);

            var req = request with
            {
                FilterRik = request.IsUserManager ? request.FilterRik : userContext.RikId,
                SucursalId = userContext.SucursalId,
            };

            var prospectosResult = await prospectosRepository.GetAsync(req);
            if (prospectosResult is null || prospectosResult.Count == 0)
            {
                return Result<ProspectosResponse>.Failure(["No se encontraron prospectos"]);
            }

            var response = ProspectosMapper.ToResponse(prospectosResult);
            return Result<ProspectosResponse>.Success(response);
        }
    }
}
