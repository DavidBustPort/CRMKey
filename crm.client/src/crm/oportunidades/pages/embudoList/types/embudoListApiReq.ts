export interface EmbudoListApiRequest {
    page: number
    itemsPerPage: number
    isUserManager: boolean
    filterRik: number | null
    filterByName: string | null
    filterMonth: number | null
    filterYear: number | null
    filterEtapa: number | null
}
