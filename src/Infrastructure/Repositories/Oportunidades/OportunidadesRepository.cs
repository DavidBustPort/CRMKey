using Application.Common.Enums;
using Application.Common.Interfaces;
using Application.Features.Oportunidades;
using Application.Features.Oportunidades.ActualizarVpo;
using Application.Features.Oportunidades.CancelarOportunidad;
using Application.Features.Oportunidades.Get;
using Dapper;
using System.Data;

namespace Infrastructure.Repositories.Oportunidades
{
    public class OportunidadesRepository(ISqlConnectionFactory factory) : IOportunidadesRepository
    {
        public async Task<bool> ActualizarVpo(ActualizarVpoCommand command, CancellationToken ct)
        {
            using var db = await factory.CreateConnection();
            const string sql = @"
                UPDATE CrmOportunidades
                SET MontoProyecto = @vpo
                WHERE Id_Emp = 1
                    AND Id_Cd = @sucursalId
                    AND Id_Op = @oportunidadId";

            try
            {
                var rowsAffected = await db.ExecuteAsync(new CommandDefinition(sql, new
                {
                    vpo = command.Vpo,
                    sucursalId = command.SucursalId,
                    oportunidadId = command.OportunidadId
                }, cancellationToken: ct));

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando vpo de oportunidad: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> CancelarOportunidad(CancelarOportunidadCommand command, CancellationToken ct)
        {
            using var db = await factory.CreateConnection();
            const string sql = @"
                UPDATE CrmOportunidades
                SET Estatus = @estatus,
                    Id_Causa = @causaId,
                    FechaModificacion = @now,
                    FechaCancelacion = @now
                WHERE Id_Emp = 1
                    AND Id_Cd = @sucursalId
                    AND Id_Op = @oportunidadId
                    AND Estatus <> @estatusCancelada";
            try
            {
                var rowsAffected = await db.ExecuteAsync(new CommandDefinition(sql, new
                {
                    estatus = (int)EtapasOportunidades.X,
                    causaId = command.CausaId,
                    now = DateTime.Now,
                    sucursalId = command.SucursalId,
                    oportunidadId = command.OportunidadId,
                    estatusCancelada = (int)EtapasOportunidades.C
                }, cancellationToken: ct));

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error actualizando cancelacion oportunidad: {ex.Message}");
                return false;
            }
        }

        public async Task<IReadOnlyList<OportunidadesDto>> GetAsync(GetOportunidadesQuery query)
        {
            using var db = await factory.CreateConnection();
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
