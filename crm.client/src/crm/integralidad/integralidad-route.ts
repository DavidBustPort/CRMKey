import type { RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
	{
		path: '/integralidad',
		name: 'Integralidad',
		component: () => import('./AppIntegralidad.vue'),
        meta: {
            requiresAuth: true,
            showInSidebar: true,
            isSidebarGroup: true,
            icon: 'fa-chart-pie',
            fullWidth: false,
            layoutType: 'container-fluid',
            allowRikFiltering: true,
            showLoading: true
        }
	}
]
export default routes
