import type { Pagination } from '@/shared/components/customPagination/types'
import type { Integralidad } from '../types/integralidad'

interface IntegralidadFilters {
    date: {
        month: number,
        year: number
    } | null
    uen: number | null
    segmento: number | null
    cliente: number | null
}

export interface IntegralidadState {
    integralidadList: Integralidad[]
    filters: IntegralidadFilters
    isLoading: boolean
    pagination: Pagination
}
