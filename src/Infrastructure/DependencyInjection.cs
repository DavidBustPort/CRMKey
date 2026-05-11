using Application.Common.Interfaces;
using Infrastructure.Auth;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddScoped<IDatabaseResolverService, DatabaseResolverService>();

            IConfigurationSection jwt = configuration.GetSection("Jwt");
            services.Configure<JwtOptions>(jwt);

            var jwtSettings = jwt.Get<JwtOptions>();
            if (jwtSettings is null || string.IsNullOrEmpty(jwtSettings.Key))
                throw new Exception("La configuracion de jwt es requerida");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.IncludeErrorDetails = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();
            services.AddSingleton<ITokenService, TokenService>();

            var repositoryTypes = typeof(DashboardRepository).Assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"));
            foreach (var repositoryType in repositoryTypes)
            {
                var interfaceType = repositoryType.GetInterfaces().FirstOrDefault(i => i.Name == $"I{repositoryType.Name}");
                if (interfaceType is not null)
                    services.AddScoped(interfaceType, repositoryType);
            }
        }
    }
}
