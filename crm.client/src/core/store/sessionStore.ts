import { defineStore } from 'pinia'
import type { ExternalSession } from '../types/externalSession'

export const useSessionStore = defineStore('session', {
    state: (): ExternalSession  => ({
        loggedIn: false,
        userId: null,
        userName: null,
        role: null,
        sucursalId: null,
        rikId: null
    }),
    getters: {
        isLoggedInd: (state) => state.loggedIn && !!state.userId,
        isUserManager: (state) => state.role === 'gte'
    },
    actions: {
        setSession(session: ExternalSession) {
            this.loggedIn = session.loggedIn
            this.userId = session.userId
            this.userName = session.userName
            this.role = session.role
            this.sucursalId = session.sucursalId
            this.rikId = session.rikId
        }
    }
})
