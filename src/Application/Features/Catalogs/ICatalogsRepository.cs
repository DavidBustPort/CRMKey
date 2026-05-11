using Application.Common.DTOs;

namespace Application.Features.Catalogs
{
    public interface ICatalogsRepository
    {
        Task<IReadOnlyList<CatalogsResponse>> GetRiksAsync(int? sucursalId, CancellationToken ct);
        Task<IReadOnlyList<CatalogsResponse>> GetUensAsync(CancellationToken ct);
        Task<IReadOnlyList<CatalogsResponse>> GetSegmentosAsync(int UenId, CancellationToken ct);
        Task<IReadOnlyList<CatalogsResponse>> GetCausasCancelacion(CancellationToken ct);
    }
}
