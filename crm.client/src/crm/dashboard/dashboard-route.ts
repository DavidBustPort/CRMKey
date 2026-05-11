import type { RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
	{
		path: '/',
		name: 'Inicio',
		component: () => import('./AppDashboard.vue'),
        meta: {
            requiresAuth: true,
            showInSidebar: true,
            isSidebarGroup: true,
            icon: 'fa-house',
            allowRikFiltering: true
        }
	}
]
export default routes
