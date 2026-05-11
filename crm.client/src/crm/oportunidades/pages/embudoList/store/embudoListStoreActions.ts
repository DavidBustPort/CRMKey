import { EmbudoListService } from '../services/embudoList-service'
import debounce from 'lodash/debounce'
import type { useEmbudoListStore } from './embudoListStore'

type StoreContext = ReturnType<typeof useEmbudoListStore>

const debouncedFetch = debounce(async (store: StoreContext) => {
    await store.getEmbudoList()
}, 400)

interface Actions {
    getEmbudoList(): Promise<void>
    getEmbudoListDebounce(immediate?: boolean): Promise<void>
    setItemsPerPage(itemsPerPage: number): void
    clearFilters(): void
}

export const actions: Actions = {
    async getEmbudoList(this: StoreContext): Promise<void> {
        this.isLoading = true
        this.pagination.loading = true

        const data = await EmbudoListService.getEmbudo(this.apiListParams)

        if (data) {
            this.oportunidades = data
            this.pagination.totalRows = data.totalRows
            this.isLoading = false
            this.pagination.loading = false
        }
    },

    async getEmbudoListDebounce(this: StoreContext, immediate: boolean = false): Promise<void> {
        if (immediate) {
            debouncedFetch.cancel()
            return await this.getEmbudoList()
        }
        debouncedFetch(this)
    },

    setItemsPerPage(this: StoreContext, itemsPerPage: number): void {
        this.pagination.itemsPerPage = itemsPerPage
        this.pagination.currentPage = 1
        debouncedFetch(this)
    },

    clearFilters(this: StoreContext): void {
        this.filters.date = null
        this.filters.byNombre = null
        this.filters.byEtapa = null

        debouncedFetch(this)
    }
}
