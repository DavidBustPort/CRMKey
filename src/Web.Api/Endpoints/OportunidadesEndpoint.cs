using Application.Features.Oportunidades.CancelarOportunidad;
using Application.Features.Oportunidades.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Endpoints
{
    public class OportunidadesEndpoint : IEndpoints
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/oportunidades")
                           .RequireAuthorization();
            group.MapGet("", GetOportunidades);
            group.MapDelete("", CancelarOportunidad);
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

        private async Task<IResult> CancelarOportunidad(
            [FromBody] CancelarOportunidadCommand command,
            ISender sender)
        {
            var result = await sender.Send(command);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
