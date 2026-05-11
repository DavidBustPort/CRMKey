import Swal, { type SweetAlertResult } from 'sweetalert2'

interface Alert {
    loading(title?: string, text?: string): void
    close(): void
    success(title?: string, text?: string): Promise<SweetAlertResult>
    toastSuccess(message: string): void
    error(message: string): void
}

export function useAlert(): Alert {
    const loading = (title: string = 'Cargando...', text: string = ''): void => {
        Swal.fire({
            title,
            text,
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading()
            }
        })
    }

    const close = (): void => Swal.close()

    const success = async (
        title: string = '¡Guardado con éxito!',
        text: string = 'La operación se completó correctamente.'
    ): Promise<SweetAlertResult> => {
        return await Swal.fire({
            title,
            icon: 'success',
            text,
            confirmButtonText: 'Volver atrás',
            allowOutsideClick: false
        })
    }

    const toastSuccess = (message: string): void => {
        const toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            color: '#fff',
            background: '#1e1e1e',
            iconColor: '#a5dc86',
            didOpen: (toast) => {
                toast.style.borderLeft = '5px solid #a5dc86'
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        })

        toast.fire({
            icon: 'success',
            title: message
        })
    }

    const error = (message: string): void => {
        const toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
            timerProgressBar: true,
            color: '#fff',
            background: '#1e1e1e',
            iconColor: '#f27474',
            didOpen: (toast) => {
                toast.style.borderLeft = '5px solid #d33'
                toast.addEventListener('mouseenter', Swal.stopTimer)
                toast.addEventListener('mouseleave', Swal.resumeTimer)
            }
        })

        toast.fire({
            icon: 'error',
            title: message
        })
    }

    return {
        loading,
        close,
        success,
        toastSuccess,
        error
    }
}
