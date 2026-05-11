using Application.Common.Enums;

namespace Application.Features.Oportunidades.Get
{
    public record OportunidadesResponse(int TotalRows, List<Oportunidades> Oportunidades);

    public record Oportunidades(
        int ClienteId,
        int ProspectoId,
        int OportunidadId,
        string Cliente,
        string FuenteProspecto,
        string Aplicacion,
        string TipoVenta,
        decimal Vpo,
        decimal Vpt,
        decimal VpmAntesCierre,
        string Integralidad,
        EtapasOportunidades Etapa,
        string? CausaCancelacion,
        decimal TotalAcys,
        decimal TotalFacturacion,
        Detalle Detalle);

    public record Detalle(
        DateTime FechaRegistro,
        string DuracionOportunidad,
        List<DetalleProductos> Productos);

    public record DetalleProductos(
        long Sku,
        string Descripcion,
        int Unidades,
        string? Presentacion,
        string? UniNe,
        double Precio,
        bool EstatusAutorizacion);
}
