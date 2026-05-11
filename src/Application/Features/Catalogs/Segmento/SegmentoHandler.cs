using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Common.Wrappers;

namespace Application.Features.Catalogs.Segmento
{
    public class SegmentoHandler(ICatalogsRepository catalogsRepository) : IApiRequestHandler<SegmentoQuery, IReadOnlyList<CatalogsResponse>>
    {
        public async Task<Result<IReadOnlyList<CatalogsResponse>>> Handle(SegmentoQuery request, CancellationToken ct)
        {
            var seg = await catalogsRepository.GetSegmentosAsync(request.UenId, ct);
            return Result<IReadOnlyList<CatalogsResponse>>.Success(seg);
        }
    }
}
