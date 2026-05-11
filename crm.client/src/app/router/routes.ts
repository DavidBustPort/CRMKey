import type { RouteRecordRaw } from 'vue-router'
import dashboardRoute from '@/crm/dashboard/dashboard-route'
import prospectosRoute from '@/crm/prospectos/prospectos-route'
import reportesRoute from '@/crm/reportes/reportes-route'
import integralidadRoute from '@/crm/integralidad/integralidad-route'
import oportunidadesRoute from '@/crm/oportunidades/oportunidades-route'

const routes: RouteRecordRaw[] = [
    ...dashboardRoute,
    ...prospectosRoute,
    ...oportunidadesRoute,
    ...integralidadRoute,
    ...reportesRoute,
    {
        path: '/unauthorized',
        name: 'unauthorized',
        component: () => import('../views/UnauthorizedView.vue')
    },
    {
        path: '/:pathMatch(.*)*',
        component: () => import('../views/NotFoundView.vue')
    }
]
export default routes
