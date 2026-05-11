import { ExternalSessionService } from '../services'
import { AuthService } from '../services/auth-service'
import { useAuthStore } from '../store/authStore'
import { ref, type Ref } from 'vue'

interface AuthRefresh {
    isRefreshing: Ref<boolean>
    handleRefresh: () => Promise<string | null>
    refreshSubscribers: Array<(token: string) => void>
}

const isRefreshing = ref<boolean>(false)
let refreshSubscribers: Array<(token: string) => void> = []

export function useAuthRefresh(): AuthRefresh {
    const authStore = useAuthStore()

    const onRefreshed = (token: string) => {
        refreshSubscribers.forEach(cb => cb(token))
        refreshSubscribers = []
    }

    const handleRefresh = async (): Promise<string | null> => {
        try {
            const externalSession = await ExternalSessionService.checkSession()
            if (!externalSession.loggedIn) throw new Error('NOT_LOGGED_IN')

            const authData = await AuthService.refreshToken({
                userId: externalSession.userId!,
                sucursalId: externalSession.sucursalId
            }, authStore.apiRefreshToken!)

            if (authData.succeeded && authData.data?.token && authData.data?.refreshToken) {
                authStore.setApiRefreshToken(authData.data)
                onRefreshed(authData.data.token)
                return authData.data.token
            }
            throw new Error('REFRESH_FAILED')

        } catch {
            authStore.logout()
            return null
        }
        finally {
            isRefreshing.value = false
        }
    }

    return {
        isRefreshing,
        handleRefresh,
        refreshSubscribers
    }
}
