export interface Pagination {
    currentPage: number
    totalRows: number
    title?: string
    showTitle?: boolean
    arrayItemsPerPage?: number[]
    maxPages?: number
    itemsPerPage: number
    showItemsPerPageOptions?: boolean
    loading?: boolean
}

export interface PaginationConfig {
    config: Pagination
}
