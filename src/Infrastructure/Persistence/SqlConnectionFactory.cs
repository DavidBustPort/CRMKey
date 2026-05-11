using Application.Common.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Domain.Enums;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence
{
    public class SqlConnectionFactory(
        IConfiguration configuration,
        IUserContext userContext,
        IServiceProvider serviceProvider,
        IMemoryCache memoryCache) : ISqlConnectionFactory
    {
        public async Task<IDbConnection> CreateConnection(SiteMode? forceMode = SiteMode.sianweb, int? sucursalId = null)
        {
            var modeToUse = forceMode ?? userContext.Mode;
            return modeToUse switch
            {
                SiteMode.sianweb => await CreateDynamicSIANWEBConnection(sucursalId),
                SiteMode.sianwebcentral => new SqlConnection(configuration.GetConnectionString("SIANWEBCENTRAL")),
                SiteMode.siancentral => new SqlConnection(configuration.GetConnectionString("SIANCENTRAL")),
                _ => throw new ArgumentException("No se pudo establecer una conexión porque el modo de aplicacion (header 'mode') no es válido o no fue especificado.")
            };
        }

        private async Task<string> GetDatabaseNameAsync(int sucursalId)
        {
            string cacheKey = $"db_name_{sucursalId}";
            return await memoryCache.GetOrCreateAsync(cacheKey, async entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60);

                using var scope = serviceProvider.CreateScope();
                var dbResolver = scope.ServiceProvider.GetRequiredService<IDatabaseResolverService>();

                return await dbResolver.GetDbNameAsync(sucursalId);
            }) ?? throw new InvalidOperationException($"No se encontro el nombre de la base de datos, sucursalId: {userContext.SucursalId}");
        }

        private async Task<IDbConnection> CreateDynamicSIANWEBConnection(int? sucursalId)
        {
            string baseConnString = configuration.GetConnectionString("SIANWEB")
                ?? throw new InvalidOperationException("Connection string 'SIANWEB' not found.");

            bool useDefaultDatabase = configuration.GetValue<bool>("DbSettings:UseDefaultDatabase");
            string defaultDatabase = configuration.GetSection("DbSettings:DefaultDatabase").Value ?? "";

            string targetDatabase;
            if (useDefaultDatabase && !string.IsNullOrEmpty(defaultDatabase))
                targetDatabase = defaultDatabase;
            else
            {
                int? sucursalIdToUse = sucursalId ?? userContext.SucursalId;
                if (!sucursalIdToUse.HasValue) throw new InvalidOperationException("No se establecio sucursalId");

                targetDatabase = await GetDatabaseNameAsync(sucursalIdToUse.Value);
            }

            var builder = new SqlConnectionStringBuilder(baseConnString) { InitialCatalog = targetDatabase };
            return new SqlConnection(builder.ConnectionString);
        }
    }
}
