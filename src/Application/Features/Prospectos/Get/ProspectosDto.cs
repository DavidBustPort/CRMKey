namespace Application.Features.Prospectos.Get
{
    public record ProspectosDto(
        int IdProspecto,
        int IdCliente,
        string Prospecto,
        string? Observaciones,
        DateTime? FechaRegistro,
        decimal VPO,
        bool EstatusRegistro,
        string Fuente,
        string? Mkt_EStatus,
        string? Gte_EStatus,
        string? Rik_EStatus,
        int TotalOportunidadesAnalisis,
        int TotalOportunidadesPromocion,
        int TotalOportunidadesNegociacion,
        int TotalOportunidadesCierre,
        decimal TotalVpoAnalisis,
        decimal TotalVpoPromocion,
        decimal TotalVpoNegociacion,
        decimal TotalVpoCierre,
        int RowNum,
        int RecordCount);
}
