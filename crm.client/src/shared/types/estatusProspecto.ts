export const EstatusProspecto = {
    ABIERTO: 1,
    CERRADO: 0
}

export type EstatusProspecto = typeof EstatusProspecto[keyof typeof EstatusProspecto]
