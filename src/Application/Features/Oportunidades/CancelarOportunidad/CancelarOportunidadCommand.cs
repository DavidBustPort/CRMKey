using Application.Common.Interfaces;

namespace Application.Features.Oportunidades.CancelarOportunidad
{
    public record CancelarOportunidadCommand(
        int OportunidadId,
        int CausaId,
        int? SucursalId = null) : IApiRequest<bool>;
}
