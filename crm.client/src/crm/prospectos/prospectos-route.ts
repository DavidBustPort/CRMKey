import type { RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
	{
		path: '/prospectos',
		name: 'Prospectos',
		component: () => import('./AppProspectos.vue'),
        meta: {
            requiresAuth: true,
            showInSidebar: true,
            isSidebarGroup: true,
            icon: 'fa-person-walking-dashed-line-arrow-right'
        },
        children: [
            {
                path: '',
                name: 'Lista de prospectos',
                component: () => import('./pages/prospectosList/ProspectosList.vue'),
                meta: {
                    fullWidth: true,
                    showLoading: true
                }
            },
            {
                path: 'insert',
                name: 'Crear prospecto',
                component: () => import('./pages/prospectosUpsert/ProspectosInsert.vue'),
                meta: {
                    fullWidth: true
                }
            }
        ]
	}
]
export default routes
