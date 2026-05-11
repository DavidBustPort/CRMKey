import { defineStore } from 'pinia'
import type { ApiTokenRes } from '../types/api/apiToken'

interface AuthState {
    apiToken: string | null
    apiRefreshToken: string | null
    errorMessage?: string
}

export const useAuthStore = defineStore('auth', {
    state: (): AuthState => ({
        apiToken: null,
        apiRefreshToken: null
    }),
    getters: {
        isAuthenticated: (state) => !!state.apiToken && !!state.apiRefreshToken
    },
    actions: {
        setApiToken(res: ApiTokenRes): void {
            this.apiToken = res.token
            this.apiRefreshToken = res.refreshToken
        },

        setApiRefreshToken(res: ApiTokenRes): void {
            this.apiToken = res.token
            this.apiRefreshToken = res.refreshToken
        },

        logout(): void {
            this.apiToken = null
            this.apiRefreshToken = null
            this.$reset()
            sessionStorage.clear()
        }
    },
    persist: true
})
