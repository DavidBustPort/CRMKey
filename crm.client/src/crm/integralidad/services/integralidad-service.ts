import { apiInstance } from '@/core/services'
import type { Integralidad } from '../types/integralidad'
import type { IntegralidadApiListRequest } from '../types/integralidadApiReq'
import type { ApiWrapper } from '@/core/types/apiWrapper'

export const IntegralidadService = {
    getIntegralidad: async (query: IntegralidadApiListRequest): Promise<Integralidad[]> => {
        try {
            let url = 'integralidad' +
                `?isUserManager=${query.isUserManager}` +
                `&filterMonth=${query.filterMonth}` +
                `&filterYear=${query.filterYear}`

            if (query.filterRik) url += `&filterRik=${query.filterRik}`

            const res = await apiInstance.get<ApiWrapper<Integralidad[]>>(url)

            return res.data.succeeded ? res.data.data || [] : []
        }
        catch { return [] }
    }
}
