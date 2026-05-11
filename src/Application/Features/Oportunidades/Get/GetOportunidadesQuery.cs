using Application.Common.Enums;
using Application.Common.Interfaces;

namespace Application.Features.Oportunidades.Get
{
    public record GetOportunidadesQuery(
        int Page,
        int ItemsPerPage,
        bool IsUserManager,
        int? FilterRik,
        string? FilterByName,
        int? FilterMonth,
        int? FilterYear,
        EtapasOportunidades? FilterEtapa,
        int? SucursalId = null) : IApiRequest<OportunidadesResponse>;
}
