using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Common.Wrappers;

namespace Application.Features.Catalogs.CausasCancelacion
{
    public class CausaCancelacionHandler(ICatalogsRepository catalogsRepository) : IApiRequestHandler<CausaCancelacionQuery, IReadOnlyList<CatalogsResponse>>
    {
        public async Task<Result<IReadOnlyList<CatalogsResponse>>> Handle(CausaCancelacionQuery request, CancellationToken ct)
        {
            var cc = await catalogsRepository.GetCausasCancelacion(ct);
            return Result<IReadOnlyList<CatalogsResponse>>.Success(cc);
        }
    }
}
