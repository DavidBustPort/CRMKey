using Application.Common.DTOs;
using Application.Common.Interfaces;
using Application.Features.Catalogs;
using Dapper;
using Domain.Enums;

namespace Infrastructure.Repositories.Catalogs
{
    public class CatalogsRepository(ISqlConnectionFactory factory) : ICatalogsRepository
    {
        public async Task<IReadOnlyList<CatalogsResponse>> GetCausasCancelacion(CancellationToken ct)
        {
            using var db = await factory.CreateConnection(SiteMode.sianweb);
            try
            {
                string sql = @$"SELECT Id_Causa AS Id
                            , Descripcion       AS Name
                            FROM CrmCausasCancelacion
                            WHERE Estatus = 1";
                var dbo = await db.QueryAsync<CatalogsResponse>(
                    new CommandDefinition(sql, cancellationToken: ct)
                );
                return dbo.ToList() ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching causas cancelaction data: {ex.Message}");
                return [];
            }
        }

        public async Task<IReadOnlyList<CatalogsResponse>> GetRiksAsync(int? sucursalId, CancellationToken ct)
        {
            using var db = await factory.CreateConnection(SiteMode.sianweb, sucursalId);
            try
            {
                string sql = @$"SELECT r.Id_Rik AS Id
                            , r.Rik_Nombre      AS Name
                            FROM CatRik r
                            JOIN CatUsuario u ON
                                r.Id_Rik = u.Id_Rik
                            WHERE r.Rik_Activo = 1
                                AND u.U_Activo = 1";
                var dbo = await db.QueryAsync<CatalogsResponse>(
                    new CommandDefinition (sql, ct)
                );
                return dbo.ToList() ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching riks data: {ex.Message}");
                return [];
            }
        }

        public async Task<IReadOnlyList<CatalogsResponse>> GetSegmentosAsync(int UenId, CancellationToken ct)
        {
            using var db = await factory.CreateConnection(SiteMode.sianweb);
            try
            {
                string sql = @$"SELECT Id_Seg   AS Id
                            , Seg_Descripcion   AS Name
                            FROM CatSegmento
                            WHERE Id_Uen = @uenId";
                var dbo = await db.QueryAsync<CatalogsResponse>(
                    new CommandDefinition(sql, new { UenId }, cancellationToken: ct)
                );
                return dbo.ToList() ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching uens data: {ex.Message}");
                return [];
            }
        }

        public async Task<IReadOnlyList<CatalogsResponse>> GetUensAsync(CancellationToken ct)
        {
            using var db = await factory.CreateConnection(SiteMode.sianweb);
            try
            {
                string sql = @$"SELECT Id_Uen   AS Id
                            , Uen_Descripcion   AS Name
                            FROM CatUEN
                            WHERE Id_Uen NOT IN (5,6)";
                var dbo = await db.QueryAsync<CatalogsResponse>(
                    new CommandDefinition(sql, ct)
                );
                return dbo.ToList() ?? [];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching uens data: {ex.Message}");
                return [];
            }
        }
    }
}
