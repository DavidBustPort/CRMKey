import type { EtapasOportunidades } from '@/shared/types/etapasOportunidades'

interface Embudo {
    clienteId: number
    prospectoId: number
    oportunidadId: number
    cliente: string
    fuenteProspecto: string
    aplicacion: string
    tipoVenta: string
    vpo: number
    vpt: number
    vpmAntesCierre: number
    integralidad: string
    etapa: EtapasOportunidades
    causaCancelacion?: string
    totalAcys: number
    totalFacturacion: number
    detalle: EmbudoDetalle
}

interface EmbudoDetalle {
    fechaRegistro: Date
    duracionOportunidad: string
    productos: EmbudoDetalleProducto[]
}

interface EmbudoDetalleProducto {
    sku: string
    descripcion: string
    unidades: number
    precio: number
    presentacion?: string
    uniNe?: string
    estatusAutorizacion: boolean
}

export interface EmbudoList {
    totalRows: number
    oportunidades: Embudo[]
}
