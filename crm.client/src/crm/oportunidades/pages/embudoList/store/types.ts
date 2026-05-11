import type { Pagination } from '@/shared/components/customPagination/types'
import type { EmbudoList } from '../types/oportunidades'
import type { EtapasOportunidades } from '@/shared/types/etapasOportunidades'
import type { CausasCancelacion } from '@/shared/types/catalogs'

interface EmbudoFilters {
    date: {
        month: number,
        year: number
    } | null
    byNombre: string | null
    byEtapa: EtapasOportunidades | null
}

export interface EmbudoListState {
    oportunidades: EmbudoList
    pagination: Pagination
    filters: EmbudoFilters
    isLoading: boolean
    causasCancelacion: CausasCancelacion[]
}
