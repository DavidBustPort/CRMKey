import type { InternalAxiosRequestConfig } from 'axios'
import { useApp } from '../composables/useApp'
import { useAuthStore } from '../store/authStore'
import { useAppStore } from '../store/appStore'

export default async (config: InternalAxiosRequestConfig): Promise<InternalAxiosRequestConfig> => {
    const authStore = useAuthStore()
    const appStore = useAppStore()
    const { isFullyAuthenticated } = useApp()

    if (isFullyAuthenticated && !config.url?.toLowerCase().includes('auth')) {
        config.headers.Authorization = `Bearer ${authStore.apiToken}`
        config.headers.set('mode', appStore.mode)
    }
    return config
}
