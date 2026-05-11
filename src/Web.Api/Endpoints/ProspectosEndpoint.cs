using Application.Features.Prospectos.Get;
using MediatR;

namespace Web.Api.Endpoints
{
    public class ProspectosEndpoint : IEndpoints
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/prospectos")
                           .RequireAuthorization();
            group.MapGet("", GetProspectos);
        }

        private async Task<IResult> GetProspectos(
            [AsParameters] GetProspectosQuery query,
            ISender sender)
        {
            var result = await sender.Send(query);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
