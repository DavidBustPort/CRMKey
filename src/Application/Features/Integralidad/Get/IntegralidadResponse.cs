namespace Application.Features.Integralidad.Get
{
    public record IntegralidadResponse(
        int ClienteId,
        string Cliente,
        string TamanoCliente,
        int UenId,
        string Uen,
        int SegmentoId,
        string Segmento,
        decimal Ventas,
        decimal Vpt,
        decimal Vpo,
        decimal PorcentajeVpt,
        decimal PorcentajeVpo,
        decimal PorcentajeIntegralidadAplicaciones,
        decimal PorcentajePotencialIntegralidadAplicaciones,
        ClienteDetalle ClienteDetalle);

    public record ClienteDetalle(
        int TotalAplicaciones,
        IReadOnlyList<VentaPorCategoria> VentaPorCategorias,
        IReadOnlyList<Aplicaciones> AplicacionesNoVendidas,
        IReadOnlyList<Aplicaciones> AplicacionesVendidas);

    public record VentaPorCategoria(
        string Categoria,
        decimal Porcentaje);

    public record Aplicaciones(
        string Aplicacion,
        decimal Venta,
        decimal PotencialIntegralidadTeorico,
        decimal PorcentajeIntegralidad);
}
