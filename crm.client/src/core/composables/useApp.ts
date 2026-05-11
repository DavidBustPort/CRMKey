import { computed, ref, type Ref } from 'vue'
import { useAuthStore } from '../store/authStore'
import { useSessionStore } from '../store/sessionStore'
import { ExternalSessionService } from '../services'
import { AuthService } from '../services/auth-service'
import { useAppStore } from '../store/appStore'

interface App {
    isFullyAuthenticated: Ref<boolean>
    isInitializing: Readonly<Ref<boolean>>
    isInitialized: Readonly<Ref<boolean>>
    init: () => Promise<void>
}

const isInitializing = ref<boolean>(true)
const isInitialized = ref<boolean>(false)

export function useApp(): App {
    const appStore = useAppStore()
    const authStore = useAuthStore()
    const sessionStore = useSessionStore()

    const isFullyAuthenticated = computed<boolean>(() => {
        return authStore.isAuthenticated && sessionStore.isLoggedInd && appStore.mode !== null
    })

    const init = async (): Promise<void> => {
        if (isInitialized.value) return

        try {
            appStore.setPageLoading(true)
            isInitializing.value = true

            if (!sessionStore.isLoggedInd) {
                const sessionData = await ExternalSessionService.checkSession()
                sessionStore.setSession(sessionData)
            }

            if (sessionStore.isLoggedInd && !authStore.isAuthenticated) {
                const authData =  await AuthService.getToken({
                    userId: sessionStore.userId!,
                    sucursalId: sessionStore.sucursalId,
                    rikId: sessionStore.rikId
                })
                authStore.setApiToken(authData.data!)
            }
            isInitialized.value = true
        } catch {
            appStore.setPageLoading(false)
        }
        finally {
            isInitializing.value = false
            appStore.setPageLoading(false)
        }
    }

    return {
        isFullyAuthenticated,
        isInitializing,
        isInitialized,
        init
    }
}
