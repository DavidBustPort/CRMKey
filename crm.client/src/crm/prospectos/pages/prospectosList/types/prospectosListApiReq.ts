export interface ProspectosListApiRequest {
    page: number
    itemsPerPage: number
    isUserManager: boolean
    filterRik: number | null
}
