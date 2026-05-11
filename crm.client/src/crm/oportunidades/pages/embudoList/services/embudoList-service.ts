import { apiInstance } from '@/core/services'
import type { ApiWrapper } from '@/core/types/apiWrapper'
import type { EmbudoListApiRequest } from '../types/embudoListApiReq'
import type { EmbudoList } from '../types/oportunidades'

let abortController: AbortController | null = null

export const EmbudoListService = {
    getEmbudo: async (query: EmbudoListApiRequest): Promise<EmbudoList> => {
        const defaultResponse: EmbudoList = {
            oportunidades: [],
            totalRows: 0
        }

        if (!query) return defaultResponse
        if (abortController) abortController.abort()

        abortController = new AbortController()
        const signal = abortController.signal

        try {
            let url = 'oportunidades' +
                `?page=${query.page}` +
                `&itemsPerPage=${query.itemsPerPage}` +
                `&isUserManager=${query.isUserManager}`

            if (query.filterRik) url += `&filterRik=${query.filterRik}`
            if (query.filterByName) url += `&filterByName=${query.filterByName}`
            if (query.filterMonth) url += `&filterMonth=${query.filterMonth}`
            if (query.filterYear) url += `&filterYear=${query.filterYear}`
            if (query.filterEtapa) url += `&filterEtapa=${query.filterEtapa}`

            const res = await apiInstance.get<ApiWrapper<EmbudoList>>(url, {
                signal
            })

            return res.data.succeeded ? res.data.data || defaultResponse : defaultResponse
        }
        catch { return defaultResponse }
        finally { abortController = null }
    },

    cancelarOportunidad: async (oportunidadId: number, causaId: number): Promise<ApiWrapper<boolean>> => {
        try {
            const res = await apiInstance.delete<ApiWrapper<boolean>>('oportunidades', {
                data: {
                    oportunidadId,
                    causaId
                }
            })
            return res.data
        } catch {
            return {
                succeeded: false,
                message: 'Error al cancelar la oportunidad',
                data: false
            } as ApiWrapper<boolean>
        }
    }
}
