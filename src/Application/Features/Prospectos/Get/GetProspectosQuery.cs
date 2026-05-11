using Application.Common.Enums;
using Application.Common.Interfaces;

namespace Application.Features.Prospectos.Get
{
    public record GetProspectosQuery(
        int Page,
        int ItemsPerPage,
        bool IsUserManager,
        int? FilterRik,
        int? FilterMonth,
        int? FilterYear,
        string? FilterNombre,
        EtapasOportunidades? FilterEtapaOportunidad,
        int? FilterTipoProspecto,
        string? FilterEtapaLead,
        int? FilterRegistro,
        EstatusProspecto? FilterEstatus,
        int? SucursalId = null
        ) : IApiRequest<ProspectosResponse>;
}
