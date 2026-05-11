using Application.Common.Enums;
using Application.Common.Helpers;

namespace Application.Features.Oportunidades.Get
{
    public static class OportunidadesMapper
    {
        public static OportunidadesResponse ToResponse(IReadOnlyList<OportunidadesDto> oportunidades)
        {
            int totalRows = oportunidades[0].RecordCount;

            var embudo = oportunidades.Select(dto => new Oportunidades(
                dto.IdCliente,
                dto.IdProspecto,
                dto.IdOportunidad,
                dto.Cliente,
                dto.Fuente,
                dto.Aplicacion,
                dto.TipoVenta,
                dto.Vpo,
                dto.Vpt,
                dto.VpmAntesCierre,
                dto.Integralidad,
                (EtapasOportunidades)dto.Estatus,
                dto.CausaCancelacion,
                dto.Acys,
                dto.Facturacion,
                new Detalle(
                    dto.FechaCreacion,
                    DateHelper.TiempoTranscurrido(dto.FechaCreacion, dto.FechaFinal ?? DateTime.Now)
                    , [])
                )).ToList();

            return new OportunidadesResponse(totalRows, embudo);
        }
    }
}
