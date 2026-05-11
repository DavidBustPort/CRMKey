using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Common.Wrappers;

namespace Application.Features.Catalogs.Rik
{
    public class RikHandler(ICatalogsRepository catalogsRepository) : IApiRequestHandler<RikQuery, IReadOnlyList<CatalogsResponse>>
    {
        public async Task<Result<IReadOnlyList<CatalogsResponse>>> Handle(RikQuery request, CancellationToken ct)
        {
            var riks = await catalogsRepository.GetRiksAsync(request.SucursalId, ct);
            return Result<IReadOnlyList<CatalogsResponse>>.Success(riks);
        }
    }
}
