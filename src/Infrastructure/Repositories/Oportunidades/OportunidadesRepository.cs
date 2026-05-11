using Application.Common.Interfaces;
using Application.Features.Oportunidades;
using Application.Features.Oportunidades.Get;
using Dapper;
using Domain.Enums;
using System.Data;

namespace Infrastructure.Repositories.Oportunidades
{
    public class OportunidadesRepository(ISqlConnectionFactory factory) : IOportunidadesRepository
    {
        public async Task<IReadOnlyList<OportunidadesDto>> GetAsync(GetOportunidadesQuery query)
        {
            using var db = await factory.CreateConnection(SiteMode.sianweb);
            try
            {
                var parameters = new
                {
                    sucursalId = query.SucursalId,
                    page = query.Page,
                    itemsPerPage = query.ItemsPerPage,
                    filterRikId = query.FilterRik,
                    filterMes = query.FilterMonth,
                    filterAnio = query.FilterYear,
                    FilterByNombreCliente = query.FilterByName,
                    FilterEtapa = (int?)query.FilterEtapa,
                    FilterIncluirCanceladas = false
                };

                var dbos = await db.QueryAsync<OportunidadesDto>(
                    OportunidadesConstants.GetOportunidadesEmbudo,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (dbos is null) return [];

                return [.. dbos];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching oportunidades embudo: {ex.Message}");
                return [];
            }
        }
    }
}
