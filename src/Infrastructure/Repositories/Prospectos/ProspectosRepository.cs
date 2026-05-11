using Application.Common.Interfaces;
using Application.Features.Prospectos;
using Application.Features.Prospectos.Get;
using Dapper;
using Domain.Enums;
using System.Data;

namespace Infrastructure.Repositories.Prospectos
{
    public class ProspectosRepository(ISqlConnectionFactory factory) : IProspectosRepository
    {
        public async Task<IReadOnlyList<ProspectosDto>> GetAsync(GetProspectosQuery query)
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
                    filterNombreProspecto = query.FilterNombre,
                    filterEtapaProyecto = (int?)query.FilterEtapaOportunidad,
                    filterTipoProspecto = query.FilterTipoProspecto,
                    filterEtapaLead = query.FilterEtapaLead,
                    filterRegistro = query.FilterRegistro,
                    filterEstatus = query.FilterEstatus
                };

                var dbos = await db.QueryAsync<ProspectosDto>(
                    ProspectosConstants.GetProspectosList,
                    parameters,
                    commandType: CommandType.StoredProcedure);

                if (dbos is null) return [];

                return [.. dbos];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching prospectos list data: {ex.Message}");
                return [];
            }
        }
    }
}
