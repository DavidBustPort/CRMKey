using Application.Common.DTOs;
using Application.Common.Interfaces;

namespace Application.Features.Catalogs.Uen
{
    public record UenQuery : IApiRequest<IReadOnlyList<CatalogsResponse>>;
}
