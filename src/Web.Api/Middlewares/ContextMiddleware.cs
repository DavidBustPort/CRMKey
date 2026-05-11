using Application.Common.Interfaces;
using Domain.Enums;

namespace Web.Api.Middlewares
{
    public class ContextMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(
            HttpContext context,
            IUserContext userContext)
        {
            if (context.Request.Headers.TryGetValue("mode", out var modeValues))
            {
                var rawMode = modeValues.FirstOrDefault();
                if (Enum.TryParse<SiteMode>(rawMode, ignoreCase: true, out var parsedMode)) userContext.Mode = parsedMode;
                else userContext.Mode = SiteMode.sianweb;
            }

            await next(context);
        }
    }
}
