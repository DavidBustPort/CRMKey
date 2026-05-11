using Application.Features.Prospectos.Get;

namespace Application.Features.Prospectos
{
    public interface IProspectosRepository
    {
        Task<IReadOnlyList<ProspectosDto>> GetAsync(GetProspectosQuery query);
    }
}
