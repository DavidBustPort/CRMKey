<template>
    <button type="button" @click="initModal" class="dropdown-item">
        <FontAwesomeIcon icon="fa-eye" class="me-2 text-muted" />
        Ver información completa
    </button>
    <CustomModal ref="modalRef">
        <div v-if="isLoading" class="text-center p-5">
            <div class="spinner-border text-primary" role="status"></div>
            <div class="mt-2 text-muted">Cargando datos...</div>
        </div>
    </CustomModal>
</template>

<script lang="ts" setup>
import CustomModal from '@/shared/components/customModal/CustomModal.vue'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { ref } from 'vue'

const isLoading = ref<boolean>(false)
const modalRef = ref<InstanceType<typeof CustomModal>>()

const initModal = async () => {
    modalRef.value?.open({
        title: 'Prospecto Detalle',
        size: 'md',
        animation: 'flip',
        showConfirmButton: false,
        closeButtonText: 'Cerrar'
    })
}
</script>

<style scoped>

</style>
