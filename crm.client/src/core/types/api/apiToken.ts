export interface ApiTokenReq {
    userId: number
    sucursalId?: number | null
    rikId?: number | null
}

export interface ApiTokenRes {
    token: string
    refreshToken: string
    expiresAt: string
    tokenType: string
}
