import type { EmbudoListState } from './types'

export const state = (): EmbudoListState => ({
    oportunidades: {
        oportunidades: [],
        totalRows: 0
    },
    pagination: {
        currentPage: 1,
        totalRows: 0,
        itemsPerPage: 10,
        title: 'Oportunidades',
        showTitle: true,
        arrayItemsPerPage: [10, 25, 50]
    },
    filters: {
        date: null,
        byNombre: null,
        byEtapa: null
    },
    isLoading: false
})
