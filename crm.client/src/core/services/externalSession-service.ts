import axios from 'axios'
import type { ExternalSession } from '../types/externalSession'
import { useAppStore } from '../store/appStore'

/**
 * verifica la sesion en sianweb y siancentral a través de
 * un archivo .ashx
 */

export const ExternalSessionService = {
    checkSession: async (): Promise<ExternalSession> => {
        const appStore = useAppStore()
        const STORAGE_KEY = 'sianweb_parent_app'

        const referrer = document.referrer
        if (referrer && !sessionStorage.getItem(STORAGE_KEY)) {
            try {
                const url = new URL(referrer)
                const hostParts = url.pathname.split('/').filter(p => p !== '')
                if (hostParts.length > 0) {
                    const detectedApp = hostParts[0]
                    if (detectedApp) sessionStorage.setItem(STORAGE_KEY, detectedApp)
                    else throw new Error('HOST_NOT_FOUND')
                }
            } catch {
                throw new Error('INVALID_REFERRER')
            }
        }

        const activeApp = sessionStorage.getItem(STORAGE_KEY)

        if (!activeApp) {
            throw new Error('MISSING_ORIGIN_FROM_REFERRER')
        }

        const url = `/${activeApp}/externalAuth.ashx`

        const mode = activeApp.toLowerCase().includes('siancentral') ? 'siancentral' : 'sianweb'
        appStore.setMode(mode)

        const response = await axios.get<ExternalSession>(url, {
            withCredentials: true
        })

        return response.data
    }
}
