namespace Application.Features.Integralidad.Get
{
    public static class IntegralidadMapper
    {
        public static IReadOnlyList<IntegralidadResponse> ToResponse(IReadOnlyList<IntegralidadDto> dtos)
        {
            var clientes = dtos
                .GroupBy(r => r.ClienteId)
                .Select(g => {
                    var row = g.First();

                    var aplicacionesConVenta = g
                        .Where(x => x.Venta > 0)
                        .Select(s => new Aplicaciones(s.Aplicacion, s.Venta, 0, 0))
                        .ToList();

                    var aplicacionesSinVenta = g
                        .Where(x => x.Venta <= 0)
                        .Select(s => new Aplicaciones(s.Aplicacion, s.Venta, 0, 0))
                        .ToList();

                    var detalle = new ClienteDetalle(
                        g.Count(),
                        [],
                        aplicacionesSinVenta,
                        aplicacionesConVenta);

                    decimal TotalVentas = g.Sum(x => x.Venta);

                    return new IntegralidadResponse(
                        g.Key,
                        row.Cliente,
                        row.TamanoCliente,
                        row.UenId,
                        row.Uen,
                        row.SegmentoId,
                        row.Segmento,
                        TotalVentas,
                        row.Vpt,
                        row.Vpo,
                        0,
                        0,
                        0,
                        0,
                        detalle);
                }).ToList();

            return clientes;
        }
    }
}
