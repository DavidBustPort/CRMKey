<template>
    <div class="row">
        <div class="col">
            <div class="d-flex justify-content-between align-items-center">
                <h2 class="text-primary fw-bold ps-3 border-start border-4 border-primary">Nuevo prospecto</h2>
            </div>
        </div>
    </div>
    <div class="card mt-3">
        <div class="card-header text-end">
            <a
                href="#"
                type="button"
                class="text-info fw-bold btn btn-link"
                @click.prevent="openLeadsModal"
            >
                <FontAwesomeIcon icon="fa-link" />
                ¿Quieres importar desde un Lead?
            </a>
        </div>
        <div class="card-body">
            <ProspectosForm />
        </div>
    </div>
    <CustomModal ref="modalRef">
        <ProspectosLeads />
    </CustomModal>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import CustomModal from '@/shared/components/customModal/CustomModal.vue'
import { ref } from 'vue'
import ProspectosForm from './components/prospectosForm.vue/ProspectosForm.vue'
import ProspectosLeads from './components/prospectosLeads/ProspectosLeads.vue'

const modalRef = ref<InstanceType<typeof CustomModal> | null>(null)

const openLeadsModal = (): void => {
    modalRef.value?.open({
        title: 'Importar desde Lead',
        size: 'lg',
        animation: 'fade',
        showCloseButtonInHeader: true,
        showConfirmButton: false,
        closeButtonText: 'Cerrar'
    })
}
</script>
