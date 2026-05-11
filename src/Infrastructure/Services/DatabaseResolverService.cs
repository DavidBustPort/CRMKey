using Application.Common.Interfaces;
using Dapper;
using Domain.Enums;

namespace Infrastructure.Services
{
    public class DatabaseResolverService(ISqlConnectionFactory factory) : IDatabaseResolverService
    {
        public async Task<string?> GetDbNameAsync(int sucursalId)
        {
            using var db = await factory.CreateConnection(SiteMode.siancentral);
            try
            {
                return await db.QueryFirstOrDefaultAsync<string>(
                    "SELECT Db_Nombre FROM CatSucursal WHERE Id_Cd = @sucursalId",
                    new { sucursalId }
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching DbName data: {ex.Message}");
                return null;
            }
        }
    }
}
