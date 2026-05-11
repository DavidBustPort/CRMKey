namespace Application.Features.Prospectos.Get
{
    public record ProspectosResponse(int TotalRows, List<Prospectos> Prospectos);

    public record Prospectos(
        int IdProspecto,
        int IdCliente,
        string Prospecto,
        string? Observaciones,
        DateTime? FechaRegistro,
        decimal Vpo,
        bool EstatusRegistro,
        string Fuente,
        string? Mkt_EStatus,
        string? Gte_EStatus,
        string? Rik_EStatus,
        int TotalOportunidadesAnalisis,
        int TotalOportunidadesPromocion,
        int TotalOportunidadesNegociacion,
        int TotalOporturnidadesCierre,
        decimal TotalVpoAnalisis,
        decimal TotalVpoPromocion,
        decimal TotalVpoNegociacion,
        decimal TotalVpoCierre);
}
