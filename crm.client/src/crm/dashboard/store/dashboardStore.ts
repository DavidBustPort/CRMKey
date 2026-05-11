import { defineStore } from 'pinia'
import type { Dashboard } from '../types/dashboard'
import { useLoadingAlert } from '@/core/composables/useLoadingAlert'
import { DashboardService } from '../services/dashboard-service'

interface DashboardFilters {
    month: number
    year: number
}

interface DashboardState {
    data: Dashboard | null
    filters: [DashboardFilters, DashboardFilters]
}

const now = new Date()
const month = now.getMonth()
const year = now.getFullYear()

export const useDashboardStore = defineStore('dashboard', {
    state: (): DashboardState => ({
        data: null,
        filters: [{ month, year }, { month, year }]
    }),
    actions: {
        async fetch() {
            const { loading, close } = useLoadingAlert()

            try {
                loading('Cargando datos...')
                const response = await DashboardService.get()

            } finally { close() }
        }
    }
})
