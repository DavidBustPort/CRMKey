using Application.Common.DTOs;
using Application.Common.Interfaces;

namespace Application.Features.Catalogs.Rik
{
    public record RikQuery(int? SucursalId) : IApiRequest<IReadOnlyList<CatalogsResponse>>;
}
