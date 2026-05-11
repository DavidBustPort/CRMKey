using Application.Features.Oportunidades.Get;

namespace Application.Features.Oportunidades
{
    public interface IOportunidadesRepository
    {
        Task<IReadOnlyList<OportunidadesDto>> GetAsync(GetOportunidadesQuery query);
    }
}
