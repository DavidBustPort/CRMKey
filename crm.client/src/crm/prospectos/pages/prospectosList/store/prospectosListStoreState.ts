import type { ProspectosListState } from './types'

export const state = (): ProspectosListState => ({
    prospectos: {
        prospectos: [],
        totalRows: 0
    },
    filters: {
        date: null,
        byNombre: null,
        byTipoProspecto: null,
        byRegistro: null,
        byEstatus: null,
        byEtapaLead: null,
        byEtapaProyecto: null,
        showManagerDetails: false
    },
    isLoading: false,
    pagination: {
        currentPage: 1,
        totalRows: 0,
        itemsPerPage: 10,
        title: 'Prospectos',
        showTitle: true,
        arrayItemsPerPage: [10, 25, 50]
    }
})
