import type { ApiWrapper } from '@/core/types/apiWrapper'
import type { Dashboard } from '../types/dashboard'
import { apiInstance } from '@/core/services'

export const DashboardService = {
    get: async (): Promise<ApiWrapper<Dashboard>> => {
        try {
            const url = `/dashboard/`
            const res = await apiInstance.get<ApiWrapper<Dashboard>>(url)
            return res.data
        } catch (error: unknown) {
            const message = (error as Error).message
            return {
                succeeded: false,
                message,
                data: null
            } as ApiWrapper<Dashboard>
        }
    }
}
