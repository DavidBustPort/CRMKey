import { defineStore } from 'pinia'
import type { IntegralidadApiListRequest } from '../types/integralidadApiReq'
import type { IntegralidadState } from './types'
import type { Integralidad } from '../types/integralidad'
import { actions } from './integralidadStoreActions'
import { useSessionStore } from '@/core/store/sessionStore'
import { useAppStore } from '@/core/store/appStore'

const now = new Date()

export const useIntegralidadStore = defineStore('integralidad', {
    state: (): IntegralidadState => ({
        filters: {
            date: {
                month: now.getMonth(),
                year: now.getFullYear()
            },
            uen: null,
            segmento: null,
            cliente: null
        },
        integralidadList: [],
        isLoading: false,
        pagination: {
            currentPage: 1,
            totalRows: 0,
            itemsPerPage: 10,
            title: 'Integralidades',
            showTitle: true,
            arrayItemsPerPage: [10, 25, 50]
        }
    }),
    getters: {
        integralidadTotalFiltrada(state): Integralidad[] {
            const filter = state.filters.cliente
            if (!filter) return state.integralidadList
            return state.integralidadList.filter(item => item.clienteId === filter)

        },
        integralidadFiltrada(state): Integralidad[] {
            const list = this.integralidadTotalFiltrada

            state.pagination.totalRows = list.length
            const start = (state.pagination.currentPage - 1) * state.pagination.itemsPerPage
            const end = start + state.pagination.itemsPerPage
            return list.slice(start, end)
        },

        apiListParams(state): IntegralidadApiListRequest | null {
            if (!state.filters.date?.month || !state.filters.date?.year) return null

            const sessionStore = useSessionStore()
            const appStore = useAppStore()
            return {
                isUserManager: sessionStore.isUserManager,
                filterRik: appStore.selectedRik,
                filterMonth: state.filters.date?.month + 1,
                filterYear: state.filters.date?.year
            } as IntegralidadApiListRequest
        }
    },
    actions: {
        ...actions
    }
})
