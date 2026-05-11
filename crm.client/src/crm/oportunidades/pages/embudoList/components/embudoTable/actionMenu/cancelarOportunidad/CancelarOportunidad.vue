<template>
    <button @click="initStep1Modal" class="dropdown-item text-danger">
        <FontAwesomeIcon :icon="['fas', 'ban']" class="me-2" />
        Cancelar oportunidad
    </button>
    <CustomModal ref="modalStep1Ref">
        <div class="confirm-container">
            <div class="d-flex align-items-start p-2">
                <div class="accent-line me-4"></div>
                <div class="flex-grow-1">
                    <h5 class="text-dark fw-bold mb-2">Cancelar Oportunidad</h5>
                    <p class="text-muted lh-base">
                        Estás a punto de cancelar esta oportunidad. Esta acción moverá la oportunidad al historial de canceladas y dejará de aparecer en tu embudo activo.
                    </p>

                    <div class="info-card mt-3">
                        <FontAwesomeIcon icon="fa-info-circle" class="me-2 text-primary" />
                        <span class="small">Se te solicitará el motivo de cancelación en el siguiente paso.</span>
                    </div>
                </div>
            </div>
        </div>
    </CustomModal>
    <CustomModal ref="modalStep2Ref">
        <div class="cancellation-wrapper">
            <div class="text-center mb-4">
                <h5 class="fw-bold text-dark mb-1">Motivo de cancelación</h5>
                <p class="text-muted small">Selecciona una opción para finalizar el proceso</p>
            </div>

            <div class="motivos-grid">
                <div
                    v-for="motivo in store.causasCancelacion"
                    :key="motivo.id"
                    @click="selectedCausa = motivo.id"
                    class="motivo-compact-item"
                    :class="{ 'is-active': selectedCausa === motivo.id }"
                >
                    <div class="dot"></div>
                    <span class="text">{{ motivo.name }}</span>
                </div>
            </div>

            <div v-if="!selectedCausa && tryContinue" class="error-toast">
                <FontAwesomeIcon icon="fa-exclamation-circle" class="me-2" />
                Selecciona un motivo para continuar
            </div>
        </div>
    </CustomModal>
</template>

<script lang="ts" setup>
import CustomModal from '@/shared/components/customModal/CustomModal.vue'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { useCancelarOportunidad } from './useCancelarOportunidad'
import { useEmbudoListStore } from '../../../../store/embudoListStore'

const props = defineProps<{ oportunidadId: number }>()

const store = useEmbudoListStore()

const {
    modalStep1Ref,
    modalStep2Ref,
    selectedCausa,
    tryContinue,
    initStep1Modal
} = useCancelarOportunidad(props.oportunidadId)

void modalStep1Ref;
void modalStep2Ref;
</script>

<style scoped src="./styles.scss" lang="scss"></style>
