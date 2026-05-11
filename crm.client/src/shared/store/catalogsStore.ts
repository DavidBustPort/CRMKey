import { defineStore } from 'pinia'
import type { Rik, Uen } from '../types/catalogs'
import { CatalogsService } from '../services/catalogs-service'

export const useCatalogsStore = defineStore('catalogs', {
    state: () => ({
        uens: [] as Uen[],
        riks: [] as Rik[]
    }),
    actions: {
        async fetchUens(): Promise<void> {
            if (this.uens.length > 0) return

            try {
                this.uens = await CatalogsService.getUens()
            } finally {}
        },

        async fetchRiks(): Promise<void> {
            if (this.riks.length > 0) return

            try {
                this.riks = await CatalogsService.getRiks()
            } finally {}
        }
    }
})
