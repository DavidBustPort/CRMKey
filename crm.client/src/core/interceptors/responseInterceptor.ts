import type { AxiosError, InternalAxiosRequestConfig } from 'axios'
import axios from 'axios'
import router from '@/app/router'
import { useAuthRefresh } from '../composables/useAuthRefresh'

export default async (config: AxiosError) => {
    const { isRefreshing, refreshSubscribers, handleRefresh } = useAuthRefresh()
    const originalRequest = config.config as InternalAxiosRequestConfig & { _retry: boolean }

    if (config.response?.status === 401 && !originalRequest?._retry) {
        originalRequest._retry = true

        if (!isRefreshing.value) {
            isRefreshing.value = true

            const token = await handleRefresh()
            if (token) {
                originalRequest.headers['Authorization'] = `Bearer ${token}`
                return await axios(originalRequest)
            } else {
                router.push({ name: 'unauthorized' })
                return Promise.reject(config)
            }

        } else {
            return new Promise(resolve => {
                refreshSubscribers.push((token: string) => {
                    originalRequest.headers['Authorization'] = `Bearer ${token}`
                    resolve(axios(originalRequest))
                })
            })
        }
    }

    return Promise.reject(config)
}
