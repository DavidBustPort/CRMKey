export interface Prospectos {
    idProspecto: number
    idCliente: number
    prospecto: string
    observaciones: string | null
    fechaRegistro: Date | null
    vpo: number
    estatusRegistro: boolean
    fuente: string
    mkt_EStatus: 'Enviado' | null
    gte_EStatus: 'No enviado' | 'Enviado' | null
    rik_EStatus: 'No Procesado' | 'Procesado' | null
    totalOportunidadesAnalisis: number
    totalOportunidadesPromocion: number
    totalOportunidadesNegociacion: number
    totalOportunidadesCierre: number
    totalVpoAnalisis: number
    totalVpoPromocion: number
    totalVpoNegociacion: number
    totalVpoCierre: number
}

export interface ProspectosList {
    prospectos: Prospectos[]
    totalRows: number
}
