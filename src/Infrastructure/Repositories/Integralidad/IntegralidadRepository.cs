using Application.Common.Interfaces;
using Application.Features.Integralidad;
using Application.Features.Integralidad.Get;
using Dapper;
using Domain.Enums;
using System.Data;

namespace Infrastructure.Repositories.Integralidad
{
    public class IntegralidadRepository(ISqlConnectionFactory factory) : IIntegralidadRepository
    {
        public async Task<IReadOnlyList<IntegralidadDto>> GetAsync(GetIntegralidadQuery query)
        {
            using var db = await factory.CreateConnection(SiteMode.siancentral);
            try
            {
                var parameters = new
                {
                    filterSucursal = query.SucursalId,
                    filterAnio = query.FilterYear,
                    filterMes = query.FilterMonth,
                    filterRikId = query.FilterRik
                };

                var dbos = await db.QueryAsync<IntegralidadDto>(
                    IntegralidadConstants.GetIntegralidadList,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (dbos is null) return [];
                Console.WriteLine("dbos getasync");
                Console.WriteLine(dbos.Count());
                return [.. dbos];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching integralidad list data: {ex.Message}");
                return [];
            }
        }
    }
}
