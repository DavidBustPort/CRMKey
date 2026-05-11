namespace Application.Features.Integralidad.Get
{
    public record IntegralidadDto(
        int ClienteId,
        string Cliente,
        int IdOp,
        int IdAplicacion,
        string Aplicacion,
        int SucursalId,
        string Sucursal,
        string Zona,
        int ZonaId,        
        int UenId,
        string Uen,
        int SegmentoId,
        string Segmento,
        decimal VptTotal,
        decimal Vpo,
        decimal Vpt,
        decimal VpoMeta,
        decimal Venta,
        string TamanoCliente);
}
