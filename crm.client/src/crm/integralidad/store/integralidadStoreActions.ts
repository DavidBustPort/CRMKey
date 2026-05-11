import { IntegralidadService } from '../services/integralidad-service'
import type { useIntegralidadStore } from './integralidadStore'

type StoreContext = ReturnType<typeof useIntegralidadStore>

interface Actions {
    getIntegralidadData(): Promise<void>
    setItemsPerPage(itemsPerPage: number): void
    resetPaging(): void
    clearFilters(): void
}

export const actions : Actions = {
    async getIntegralidadData(this: StoreContext): Promise<void> {
        const params = this.apiListParams
        if (!params) return

        this.isLoading = true
        this.pagination.loading = true

        const res = await IntegralidadService.getIntegralidad(params)
        this.integralidadList = res
        this.pagination.totalRows = res.length
        this.isLoading = false
        this.pagination.loading = false
    },

    setItemsPerPage(this: StoreContext, itemsPerPage: number): void {
        this.pagination.itemsPerPage = itemsPerPage
        this.pagination.currentPage = 1
        this.getIntegralidadData()
    },

    resetPaging(this: StoreContext): void {
        this.pagination.currentPage = 1
    },

    clearFilters(this: StoreContext): void {
        this.filters.date = null
    }
}
