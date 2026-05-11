import { apiInstance } from '.'
import type { ApiTokenReq, ApiTokenRes } from '../types/api/apiToken'
import type { ApiWrapper } from '../types/apiWrapper'

export const AuthService = {
    getToken: async (query: ApiTokenReq): Promise<ApiWrapper<ApiTokenRes>> => {
        try {
            const res = await apiInstance.post('/auth/token', query)
            return res.data
        } catch (error: unknown) {
            const message = (error as Error).message
            return {
                data: null,
                message,
                succeeded: false
            } as ApiWrapper<ApiTokenRes>
        }
    },

    refreshToken: async (query: ApiTokenReq, refreshToken: string): Promise<ApiWrapper<ApiTokenRes>> => {
        try {
            const res = await apiInstance.post('/auth/refreshToken', {
                ...query,
                refreshToken
            })
            return res.data
        } catch (error: unknown) {
            const message = (error as Error).message
            return {
                data: null,
                message,
                succeeded: false
            } as ApiWrapper<ApiTokenRes>
        }
    }
}
