using Application.Features.Catalogs.CausasCancelacion;
using Application.Features.Catalogs.Rik;
using Application.Features.Catalogs.Segmento;
using Application.Features.Catalogs.Uen;
using MediatR;

namespace Web.Api.Endpoints
{
    public class CatalogsEndpoint : IEndpoints
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/catalogs")
                           .RequireAuthorization();
            group.MapGet("rik", GetRiks);
            group.MapGet("uen", GetUens);
            group.MapGet("segmento", GetSegmentos);
            group.MapGet("causas-cancelacion", GetCausasCancelacion);
        }

        private async Task<IResult> GetRiks(
            [AsParameters] RikQuery query,
            ISender sender)
        {
            var result = await sender.Send(query);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }

        private async Task<IResult> GetUens(
            [AsParameters] UenQuery query,
            ISender sender)
        {
            var result = await sender.Send(query);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }

        private async Task<IResult> GetSegmentos(
            [AsParameters] SegmentoQuery query,
            ISender sender)
        {
            var result = await sender.Send(query);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }

        private async Task<IResult> GetCausasCancelacion(
            [AsParameters] CausaCancelacionQuery query,
            ISender sender)
        {
            var result = await sender.Send(query);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
