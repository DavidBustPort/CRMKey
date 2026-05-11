import { useSessionStore } from '@/core/store/sessionStore'
import { ProspectosListService } from '../services/prospectosList-service'
import type { ProspectosListApiRequest } from '../types/prospectosListApiReq'
import type { useProspectosListStore } from './prospectosListStore'
import debounce from 'lodash/debounce'

type StoreContext = ReturnType<typeof useProspectosListStore>

interface Actions {
    getProspectosList(): Promise<void>
    getProspectosListDebounce(immediate: boolean): Promise<void>
    buildProspectosListApiRequest(): ProspectosListApiRequest
    setItemsPerPage(itemsPerPage: number): void
    clearFilters(): void
}

const debouncedFetch = debounce(async (store) => {
    await store.getProspectosList()
}, 400)

export const actions: Actions = {
    async getProspectosList(this: StoreContext): Promise<void> {
        this.isLoading = true
        this.pagination.loading = true

        const data = await ProspectosListService.getProspectos(this.buildProspectosListApiRequest())
        if (data) {
            this.prospectos = data
            this.pagination.totalRows = data.totalRows
            this.isLoading = false
            this.pagination.loading = false
        }
    },

    async getProspectosListDebounce(this: StoreContext, immediate: boolean = false): Promise<void> {
        if (immediate) {
            debouncedFetch.cancel()
            return await this.getProspectosList()
        }
        debouncedFetch(this)
    },

    buildProspectosListApiRequest(this: StoreContext): ProspectosListApiRequest {
        const sessionStore = useSessionStore()
        return {
            page: this.pagination.currentPage,
            itemsPerPage: this.pagination.itemsPerPage,
            isUserManager: sessionStore.isUserManager,
            filterRik: null
        }
    },

    setItemsPerPage(this: StoreContext, itemsPerPage: number): void {
        this.pagination.itemsPerPage = itemsPerPage
        this.pagination.currentPage = 1
        debouncedFetch(this)
    },

    clearFilters(this: StoreContext): void {
        this.filters.date = null
        this.filters.byNombre = null
        this.filters.byTipoProspecto = null
        this.filters.byRegistro = null
        this.filters.byEstatus = null
        this.filters.byEtapaLead = null
        this.filters.byEtapaProyecto = null

        debouncedFetch(this)
    }
}
