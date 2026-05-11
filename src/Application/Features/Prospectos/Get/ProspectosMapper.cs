namespace Application.Features.Prospectos.Get
{
    public static class ProspectosMapper
    {
        public static ProspectosResponse ToResponse(IReadOnlyList<ProspectosDto> prospectos)
        {
            int totalRows = prospectos[0].RecordCount;
            var listaProspectos = prospectos.Select(dto => new Prospectos(
                dto.IdProspecto,
                dto.IdCliente,
                dto.Prospecto,
                dto.Observaciones,
                dto.FechaRegistro,
                dto.VPO,
                dto.EstatusRegistro,
                dto.Fuente,
                dto.Mkt_EStatus,
                dto.Gte_EStatus,
                dto.Rik_EStatus,
                dto.TotalOportunidadesAnalisis,
                dto.TotalOportunidadesPromocion,
                dto.TotalOportunidadesNegociacion,
                dto.TotalOportunidadesCierre,
                dto.TotalVpoAnalisis,
                dto.TotalVpoPromocion,
                dto.TotalVpoNegociacion,
                dto.TotalVpoCierre
            )).ToList();

            return new ProspectosResponse(totalRows, listaProspectos);
        }
    }
}
