import type { ExternalSession, UserRole } from '../types/externalSession'

const MOCK_SIANWEBSESSION: Record<UserRole, ExternalSession> = {
    rik: {
        loggedIn: true,
        userId: 1140,
        userName: 'MOCK RIK USER',
        role: 'rik',
        sucursalId: 110,
        description: 'user: LYHER / pwd: 321',
        rikId: 475
    },
    gte: {
        loggedIn: true,
        userId: 1008,
        userName: 'MOCK MANAGER USER',
        role: 'gte',
        sucursalId: 110,
        rikId: null
    }
}

export const getMockSianWebSession = (role: UserRole): ExternalSession => MOCK_SIANWEBSESSION[role]
