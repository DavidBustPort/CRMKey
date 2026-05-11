using Application.Common.Interfaces;
using Application.Common.Wrappers;
using Domain.Enums;

namespace Application.Features.Integralidad.Get
{
    public class GetIntegralidadHandler(
        IIntegralidadRepository integralidadRepository,
        IUserContext userContext) : IApiRequestHandler<GetIntegralidadQuery, IReadOnlyList<IntegralidadResponse>>
    {
        public async Task<Result<IReadOnlyList<IntegralidadResponse>>> Handle(GetIntegralidadQuery request, CancellationToken cancellationToken)
        {
            if (userContext.Mode == SiteMode.siancentral)
                return Result<IReadOnlyList<IntegralidadResponse>>.Failure(["Modo no permitido"]);

            var req = request with
            {
                FilterRik = request.IsUserManager ? request.FilterRik : userContext.RikId,
                SucursalId = request.SucursalId
            };

            var integralidadResult = await integralidadRepository.GetAsync(request);
            if (integralidadResult is null || integralidadResult.Count == 0)
            {
                return Result<IReadOnlyList<IntegralidadResponse>>.Failure(["No se encontro datos de integralidad"]);
            }

            var response = IntegralidadMapper.ToResponse(integralidadResult);
            return Result<IReadOnlyList<IntegralidadResponse>>.Success(response);
        }
    }
}
