import Swal from 'sweetalert2'
import type { RouteLocationNormalized } from 'vue-router'

export const loadingGuard = (to: RouteLocationNormalized, _: RouteLocationNormalized) => {
    if (to.meta.showLoading) {
        Swal.fire({
            title: 'Cargando módulo',
            text: 'Por favor espere...',
            allowOutsideClick: false,
            showConfirmButton: false,
            didOpen: () => {
                Swal.showLoading()
            }
        })
    }
    return true
}
