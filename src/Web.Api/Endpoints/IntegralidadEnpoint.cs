using Application.Features.Integralidad.Get;
using MediatR;

namespace Web.Api.Endpoints
{
    public class IntegralidadEnpoint : IEndpoints
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/integralidad")
                           .RequireAuthorization();
            group.MapGet("", GetIntegralidad);
        }

        private async Task<IResult> GetIntegralidad(
            [AsParameters] GetIntegralidadQuery query,
            ISender sender)
        {
            var result = await sender.Send(query);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
