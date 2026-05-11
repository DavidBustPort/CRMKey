import { apiInstance } from '@/core/services'
import type { CausasCancelacion, Rik, Segmento, Uen } from '../types/catalogs'
import type { ApiWrapper } from '@/core/types/apiWrapper'

export const CatalogsService = {
    getRiks: async (): Promise<Rik[]> => {
        try {
            const res = await apiInstance.get<ApiWrapper<Rik[]>>('/catalogs/rik')
            return res.data.succeeded ? res.data.data ?? [] : []
        } catch { return [] }
    },

    getUens: async (): Promise<Uen[]> => {
        try {
            const res = await apiInstance.get<ApiWrapper<Uen[]>>('/catalogs/uen')
            return res.data.succeeded ? res.data.data ?? [] : []
        } catch { return [] }
    },

    getSegmentos: async(uenId: number): Promise<Segmento[]> => {
        try {
            const response = await apiInstance.get<ApiWrapper<Segmento[]>>(`/catalogs/segmento?uenId=${uenId}`)
            return response.data.succeeded ? response.data.data || [] : []
        } catch { return [] }
    },

    getCausasCancelacion: async (): Promise<CausasCancelacion[]> => {
        try {
            const res = await apiInstance.get<ApiWrapper<CausasCancelacion[]>>('/catalogs/causas-cancelacion')
            return res.data.succeeded ? res.data.data ?? [] : []
        } catch { return [] }
    },
}
