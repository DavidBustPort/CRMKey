using Application.Common.DTOs;
using Application.Common.Interfaces;

namespace Application.Features.Catalogs.Segmento
{
    public record SegmentoQuery(int UenId) : IApiRequest<IReadOnlyList<CatalogsResponse>>;
}
