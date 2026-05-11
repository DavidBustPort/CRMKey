using Application.Features.Dashboard.Get;
using MediatR;

namespace Web.Api.Endpoints
{
    public class DashboardEnpoint : IEndpoints
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/dashboard", async (
                [AsParameters] GetDashboardQuery query,
                ISender sender) =>
            {
                var result = await sender.Send(query);
                return result.Succeeded
                    ? Results.Ok(result)
                    : Results.BadRequest(result);
            })
            .RequireAuthorization();
        }
    }
}
