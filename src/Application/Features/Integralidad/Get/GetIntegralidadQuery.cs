using Application.Common.Interfaces;

namespace Application.Features.Integralidad.Get
{
    public record GetIntegralidadQuery(
        bool IsUserManager,
        int FilterMonth,
        int FilterYear,
        int? FilterRik,
        int? FilterUen,
        int? FilterSegmento,
        int? SucursalId = null) : IApiRequest<IReadOnlyList<IntegralidadResponse>>;
}
