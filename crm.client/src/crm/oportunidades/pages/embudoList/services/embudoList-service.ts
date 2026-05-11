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
    }
}
