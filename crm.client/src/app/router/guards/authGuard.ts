import { useApp } from '@/core/composables/useApp'
import type { RouteLocationNormalized } from 'vue-router'

export const authGuard = async (to: RouteLocationNormalized) => {
    const { isFullyAuthenticated, isInitializing, init } = useApp()

    if (isInitializing.value) await init()

    if (to.meta.requiresAuth && !isFullyAuthenticated.value) {
        return { name: 'unauthorized' }
    }
    return true
}
