using Application.Features.Integralidad.Get;

namespace Application.Features.Integralidad
{
    public interface IIntegralidadRepository
    {
        Task<IReadOnlyList<IntegralidadDto>> GetAsync(GetIntegralidadQuery query);
    }
}
