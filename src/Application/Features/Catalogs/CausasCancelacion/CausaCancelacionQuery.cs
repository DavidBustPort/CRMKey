using Application.Common.DTOs;
using Application.Common.Interfaces;

namespace Application.Features.Catalogs.CausasCancelacion
{
    public record CausaCancelacionQuery : IApiRequest<IReadOnlyList<CatalogsResponse>>;
}
