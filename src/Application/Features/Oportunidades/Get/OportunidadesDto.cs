namespace Application.Features.Oportunidades.Get
{
    public record OportunidadesDto(
        int IdCliente,
        int IdProspecto,
        int IdOportunidad,
        string Cliente,
        string Fuente,
        string Aplicacion,
        string TipoVenta,
        decimal Vpo,
        decimal Vpt,
        decimal VpmAntesCierre,
        string Integralidad,
        DateTime FechaCreacion,
        int Estatus,
        DateTime? FechaFinal,
        string? CausaCancelacion,
        decimal Acys,
        decimal Facturacion,
        DateTime? FechaModificacion,
        int RowNum,
        int RecordCount);
}
