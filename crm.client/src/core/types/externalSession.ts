export type UserRole = 'rik' | 'gte'

export interface ExternalSession {
    loggedIn: boolean
    userId: number | null
    userName: string | null
    role?: UserRole | null
    sucursalId: number | null
    description?: string
    rikId: number | null
}
