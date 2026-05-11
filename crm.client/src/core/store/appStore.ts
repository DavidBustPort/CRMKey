import { defineStore } from 'pinia'
import type { Mode } from '../types/app'

interface AppState {
    isPageLoading: boolean
    sidebarOpen: boolean
    layoutMode: 'container' | 'container-fluid'
    mode: Mode
    selectedRik: number | null
}

export const useAppStore = defineStore('app', {
    state: (): AppState => ({
        isPageLoading: false,
        sidebarOpen: true,
        layoutMode: 'container',
        mode: null,
        selectedRik: null
    }),
    actions: {
        setPageLoading(isLoading: boolean) {
            this.isPageLoading = isLoading
        },
        toggleSidebar() {
            this.sidebarOpen = !this.sidebarOpen
        },
        setLayoutMode(mode: 'container' | 'container-fluid') {
            this.layoutMode = mode
        },
        toggleLayoutMode() {
            this.layoutMode = this.layoutMode === 'container' ? 'container-fluid' : 'container'
        },
        setMode(mode: Mode) {
            this.mode = mode
        },
        setSelectedRik(rik: number | null) {
            this.selectedRik = rik
        }
    }
})
