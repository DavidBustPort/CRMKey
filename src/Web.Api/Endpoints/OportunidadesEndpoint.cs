using Application.Features.Oportunidades.Get;
using MediatR;

namespace Web.Api.Endpoints
{
    public class OportunidadesEndpoint : IEndpoints
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/oportunidades")
                           .RequireAuthorization();
            group.MapGet("", GetOportunidades);
        }

        private async Task<IResult> GetOportunidades(
            [AsParameters] GetOportunidadesQuery query,
            ISender sender)
        {
            var result = await sender.Send(query);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
