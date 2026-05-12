using Application.Features.Oportunidades.ActualizarVpo;
using Application.Features.Oportunidades.CancelarOportunidad;
using Application.Features.Oportunidades.Get;

namespace Application.Features.Oportunidades
{
    public interface IOportunidadesRepository
    {
        Task<IReadOnlyList<OportunidadesDto>> GetAsync(GetOportunidadesQuery query);
        Task<bool> CancelarOportunidad(CancelarOportunidadCommand command, CancellationToken ct);
        Task<bool> ActualizarVpo(ActualizarVpoCommand command, CancellationToken ct);
    }
}
