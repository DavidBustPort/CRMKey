using Application.Features.Auth.RefreshToken;
using Application.Features.Auth.Token;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api.Endpoints
{
    public class AuthEndpoint : IEndpoints
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/auth");
            group.MapPost("token", Token);
            group.MapPost("refreshToken", RefreshToken);
        }

        private async Task<IResult> Token(
            [FromBody] TokenCommand command,
            ISender sender)
        {
            var result = await sender.Send(command);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }

        private async Task<IResult> RefreshToken(
            [FromBody] RefreshTokenCommand command,
            ISender sender)
        {
            var result = await sender.Send(command);
            return result.Succeeded
                ? Results.Ok(result)
                : Results.BadRequest(result);
        }
    }
}
