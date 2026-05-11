import { defineStore } from 'pinia'
import { state } from './prospectosListStoreState'
import { actions } from './prospectosListStoreActions'

export const useProspectosListStore = defineStore('prospectosList', {
    state,
    actions: {
        ...actions
    }
})
