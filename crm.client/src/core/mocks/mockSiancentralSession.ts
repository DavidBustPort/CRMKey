import type { ExternalSession } from '../types/externalSession'

const MOCK_SIANCENTRALSESSION: ExternalSession = {
    loggedIn: true,
    userId: 1140,
    userName: 'MOCK SIANCENTRAL USER',
    role: null,
    sucursalId: null,
    rikId: null
}

export const getMockSianCentralSession = (): ExternalSession => MOCK_SIANCENTRALSESSION
