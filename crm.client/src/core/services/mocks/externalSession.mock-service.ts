import { getMockSianCentralSession } from '@/core/mocks/mockSiancentralSession'
import { getMockSianWebSession } from '@/core/mocks/mockSianwebSession'
import { useAppStore } from '@/core/store/appStore'
import type { UserRole } from '@/core/types/externalSession'

export const ExternalSessionMockService = {
    checkSession: async () => {
        const appStore = useAppStore()

        const isSianCentral: boolean = import.meta.env.VITE_MODE_SIANCENTRAL === 'true'
        appStore.mode = isSianCentral ? 'siancentral' : 'sianweb'

        if (isSianCentral) return getMockSianCentralSession()

        const mockUserRole = (import.meta.env.VITE_MOCK_USERROLE) as UserRole
        return getMockSianWebSession(mockUserRole)
    }
}
