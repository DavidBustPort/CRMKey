import { apiInstance } from '@/core/services'
import type { ProspectosList } from '../types/prospectos'
import type { ProspectosListApiRequest } from '../types/prospectosListApiReq'
import type { ApiWrapper } from '@/core/types/apiWrapper'

let abortController: AbortController | null = null

export const ProspectosListService = {
    getProspectos: async (query: ProspectosListApiRequest): Promise<ProspectosList> => {
        const defaultResponse: ProspectosList = {
            prospectos: [],
            totalRows: 0
        }

        if (!query) return defaultResponse
        if (abortController) abortController.abort()

        abortController = new AbortController()
        const signal = abortController.signal

        try {
            let url = 'prospectos' +
                `?page=${query.page}` +
                `&itemsPerPage=${query.itemsPerPage}` +
                `&isUserManager=${query.isUserManager}`

            if (query.filterRik) url += `&filterRik=${query.filterRik}`

            const res = await apiInstance.get<ApiWrapper<ProspectosList>>(url, {
                signal
            })

            return res.data.succeeded ? res.data.data || defaultResponse : defaultResponse
        }
        catch { return defaultResponse }
        finally { abortController = null }
    },

    getProspectosListFromExcel: async (query: ProspectosListApiRequest): Promise<void> => {

    }
}
