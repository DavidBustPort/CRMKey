import type { RouteRecordRaw } from 'vue-router'

const routes: RouteRecordRaw[] = [
	{
		path: '/oportunidades',
		name: 'Oportunidades',
		component: () => import('./AppOportunidades.vue'),
        meta: {
            requiresAuth: true,
            showInSidebar: true,
            isSidebarGroup: true,
            icon: 'fa-diagram-project',
        },
        children: [
            {
                path: '',
                name: 'Embudo de oportunidades',
                component: () => import('./pages/embudoList/EmbudoList.vue'),
                meta: {
                    fullWidth: true,
                    showLoading: true,
                    layoutType: 'container-fluid'
                }
            }
        ]
	}
]
export default routes
