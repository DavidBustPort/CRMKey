import type { Pagination } from '@/shared/components/customPagination/types'
import type { ProspectosList } from '../types/prospectos'
import type { EtapasOportunidades } from '@/shared/types/etapasOportunidades'
import type { TipoProspecto } from '@/shared/types/tipoProspecto'
import type { EstatusProspecto } from '@/shared/types/estatusProspecto'

interface ProspectosFilters {
    date: {
        month: number,
        year: number
    } | null
    byNombre: string | null
    byTipoProspecto: TipoProspecto
    byRegistro: RegistroProspecto | null
    byEstatus: EstatusProspecto | null
    byEtapaLead: EtapaLead | null
    byEtapaProyecto: EtapasOportunidades | null
    showManagerDetails: boolean
}

export const RegistroProspecto = {
    COMPLETO: 1,
    INCOMPLETO: 0
}

export const EtapaLead = {
    CDI_GTE: 'gte',
    CDI_RIK: 'rik',
}

type RegistroProspecto = typeof RegistroProspecto[keyof typeof RegistroProspecto]
type EtapaLead = typeof EtapaLead[keyof typeof EtapaLead]


export interface ProspectosListState {
    prospectos: ProspectosList
    filters: ProspectosFilters
    isLoading: boolean
    pagination: Pagination
}
