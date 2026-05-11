using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Common.Wrappers;

namespace Application.Features.Catalogs.Uen
{
    public class UenHandler(ICatalogsRepository catalogsRepository) : IApiRequestHandler<UenQuery, IReadOnlyList<CatalogsResponse>>
    {
        public async Task<Result<IReadOnlyList<CatalogsResponse>>> Handle(UenQuery request, CancellationToken ct)
        {
            var uens = await catalogsRepository.GetUensAsync(ct);
            return Result<IReadOnlyList<CatalogsResponse>>.Success(uens);
        }
    }
}
