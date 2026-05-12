import { ref, nextTick, type Ref } from 'vue'
import { push } from 'notivue'
import type CustomModal from '@/shared/components/customModal/CustomModal.vue'
import { useEmbudoListStore } from '../../../../store/embudoListStore'
import { EmbudoListService } from '../../../../services/embudoList-service'

interface CancelarOportunidad {
    modalStep1Ref: Ref<InstanceType<typeof CustomModal> | null>
    modalStep2Ref: Ref<InstanceType<typeof CustomModal> | null>
    selectedCausa: Ref<number | null>
    tryContinue: Ref<boolean>
    isPending: Ref<boolean>
    initStep1Modal: () => void
}

export function useCancelarOportunidad(oportunidadId: number): CancelarOportunidad {
    const store = useEmbudoListStore()

    const modalStep1Ref = ref<InstanceType<typeof CustomModal> | null>(null)
    const modalStep2Ref = ref<InstanceType<typeof CustomModal> | null>(null)
    const selectedCausa = ref<number | null>(null)
    const tryContinue = ref<boolean>(false)
    const isPending = ref<boolean>(false)

    const resetState = () => {
        selectedCausa.value = null
        tryContinue.value = false
        document.body.style.overflow = 'auto'
    }

    const initStep2Modal = () => {
        modalStep2Ref.value?.open({
            title: `Cancelar Oportunidad #${oportunidadId}`,
            size: 'lg',
            animation: 'fade',
            onConfirm: () => handleCancellation(),
            onClose: () => {
                if (isPending.value) return
                resetState()
            }
        })
    }

    const initStep1Modal = () => {
        document.body.style.overflow = 'hidden'
        modalStep1Ref.value?.open({
            title: `Cancelar Oportunidad #${oportunidadId}`,
            size: 'md',
            animation: 'slide',
            closeButtonText: 'Mantener oportunidad',
            confirmButtonText: 'Confirmar cancelación',
            onConfirm: async () => {
                await store.fetchCausasCancelacion()
                modalStep1Ref.value?.close()
                await nextTick()
                initStep2Modal()
            }
        })
    }

    const handleCancellation = async () => {
        if (selectedCausa.value === null) {
            tryContinue.value = true
            return
        }

        try {
            isPending.value = true
            modalStep2Ref.value?.close()

            const res = await EmbudoListService.cancelarOportunidad(oportunidadId, selectedCausa.value)
            if (res.succeeded && res.data) {
                modalStep2Ref.value?.close()

                store.oportunidades.oportunidades = store.oportunidades.oportunidades.filter(o => o.oportunidadId !== oportunidadId)

                push.success({
                    title: '¡Éxito!',
                    message: `La oportunidad #${oportunidadId} ha sido cancelada correctamente.`
                })
            } else {
                push.error({
                    title: 'No se pudo cancelar',
                    message: res.message || 'Hubo un problema con la solicitud.'
                })
            }
        } catch {
            push.error({
                title: 'Error de conexión',
                message: 'Inténtalo de nuevo más tarde.'
            })
        }
        finally {
            isPending.value = false
            resetState()
        }
    }

    return {
        modalStep1Ref,
        modalStep2Ref,
        selectedCausa,
        tryContinue,
        isPending,
        initStep1Modal
    }
}
