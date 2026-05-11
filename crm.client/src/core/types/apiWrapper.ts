export interface ApiWrapper<T> {
    data: T | null
    message: string | null
    succeeded: boolean
}
