import { createRouter, createWebHistory, type RouteLocationNormalized } from 'vue-router'
import routes from './routes'
import { authGuard } from './guards/authGuard'
import { loadingGuard } from './guards/loadingGuard'
import { useAppStore } from '@/core/store/appStore'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes
})

router.beforeEach(authGuard)
//router.beforeEach(loadingGuard)
router.beforeEach((to: RouteLocationNormalized) => {
    const appStore = useAppStore()

    const mode = to.meta.layoutType ?? 'container'
    appStore.setLayoutMode(mode)

    return true
})

export default router
