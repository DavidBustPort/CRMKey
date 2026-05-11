namespace Web.Api.Extensions
{
    public static class EndpointExtensions
    {
        public static void AddEndpoints(this IServiceCollection services)
        {
            var endpointType = typeof(Endpoints.IEndpoints);
            var endpointTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => endpointType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);
            foreach (var type in endpointTypes)
            {
                services.AddTransient(endpointType, type);
            }
        }

        public static IApplicationBuilder UseEndpoints(this IApplicationBuilder app)
        {
            var endpoints = app.ApplicationServices.GetServices<Endpoints.IEndpoints>();
            var routeBuilder = app as IEndpointRouteBuilder
                ?? throw new InvalidOperationException("IApplicationBuilder must be an IEndpointRouteBuilder to use endpoints.");

            var apiGroup = routeBuilder.MapGroup("/api");
            foreach (var endpoint in endpoints)
            {
                endpoint.MapEndpoints(apiGroup);
            }

            return app;
        }
    }
}
