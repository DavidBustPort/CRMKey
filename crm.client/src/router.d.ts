declare module 'vue-router' {
    interface RouteMeta {
        requiresAuth?: boolean
        showInSidebar?: boolean
        isSidebarGroup?: boolean
        icon?: string
        fullWidth?: boolean
        layoutType?: 'container' | 'container-fluid'
        showLoading?: boolean
        allowRikFiltering?: boolean
        breadcrumbName?: string
    }
}

export {}
