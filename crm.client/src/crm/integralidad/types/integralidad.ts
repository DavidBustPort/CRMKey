export interface Integralidad {
    clienteId: number
    cliente: string
    tamanoCliente: string
    uenId: number
    uen: string
    segmentoId: number
    segmento: string
    ventas: number
    vpt: number
    vpo: number
    porcentajeVpt: number
    porcentajeVpo: number
    porcentajeIntegralidadAplicaciones: number
    porcentajePotencialIntegralidadAplicaciones: number
    clienteDetalle: ClienteDetalle
}

interface ClienteDetalle {
    totalAplicaciones: number
    ventaPorCategoria: VentaPorCategoria[]
    aplicacionesNoVendidas: Aplicaciones[]
    aplicacionesVendidas: Aplicaciones[]
}

interface VentaPorCategoria {
    categoria: string
    porcentaje: number
}

export interface Aplicaciones {
    aplicacion: string
    venta: number
    potencialIntegralidadTeorico: number
    porcentajeIntegralidad: number
}
