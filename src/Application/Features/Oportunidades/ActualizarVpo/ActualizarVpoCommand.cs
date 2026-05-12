using Application.Common.Interfaces;

namespace Application.Features.Oportunidades.ActualizarVpo
{
    public record ActualizarVpoCommand(
        int OportunidadId,
        decimal Vpo,
        int? SucursalId = null) : IApiRequest<bool>;
}
