import { defineStore } from 'pinia'
import { state } from './embudoListStoreState'
import { actions } from './embudoListStoreActions'
import type { EmbudoListApiRequest } from '../types/embudoListApiReq'
import { useSessionStore } from '@/core/store/sessionStore'
import { useAppStore } from '@/core/store/appStore'

export const useEmbudoListStore = defineStore('embudoList', {
    state,
    getters: {
        apiListParams(state): EmbudoListApiRequest {
            const sessionStore = useSessionStore()
            const appStore = useAppStore()

            return {
                page: state.pagination.currentPage,
                itemsPerPage: state.pagination.itemsPerPage,
                isUserManager: sessionStore.isUserManager,
                filterRik: appStore.selectedRik,
                filterMonth: state.filters.date ? state.filters.date.month + 1 : null,
                filterYear: state.filters.date ? state.filters.date.year : null,
                filterByName: state.filters.byNombre,
                filterEtapa: state.filters.byEtapa
            } as EmbudoListApiRequest
        }
    },
    actions: {
        ...actions
    }
})
