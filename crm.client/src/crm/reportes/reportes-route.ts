import type { RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
	{
		path: '/reportes',
		name: 'Reportes',
		component: () => import('./AppReportes.vue'),
        meta: {
            requiresAuth: true,
            showInSidebar: true,
            icon: 'fa-chart-line',
            isSidebarGroup: true
        },
        children: [
            {
                path: 'gestion-proyectos',
                name: 'Gestión de Proyectos',
                component: () => import('./pages/gestionProyectos/GestionProyectos.vue'),
                meta: {
                    requiresAuth: true,
                    showInSidebar: true,
                    icon: 'fas fa-file-excel'
                }
            }
        ]
	}
]
export default routes
