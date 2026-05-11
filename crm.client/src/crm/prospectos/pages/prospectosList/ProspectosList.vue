<template>
    <div class="row mb-3">
        <div class="col-12 text-center text-md-start col-md-6">
            <h2 class="text-primary fw-bold ps-3 border-start border-4 border-primary">Lista de prospectos</h2>
        </div>
        <div class="col-12 col-md-6 mt-3 mt-md-0 text-end">
            <div class="d-md-flex justify-content-center justify-content-md-end align-items-center align-items-md-end gap-2">
                <div class="btn-md-group">
                    <button @click="exportToExcel" class="btn btn-success text-white p-2" :class="{ 'me-md-2': !sessionStore.isUserManager }">
                        <FontAwesomeIcon icon="fa-file-export" class="me-2" /> Exportar tabla a Excel
                    </button>
                    <RouterLink
                        v-if="!sessionStore.isUserManager"
                        to="/prospectos/insert"
                        class="btn btn-primary mt-2 mt-md-0 text-white p-2"
                    >
                        <FontAwesomeIcon icon="fa-user-plus" class="me-2" /> Nuevo prospecto
                    </RouterLink>
                </div>
            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-body">
            <ProspectosFilters />
            <hr class="my-4 hr-table">
            <ProspectosTable />
        </div>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { useSessionStore } from '@/core/store/sessionStore'
import ProspectosFilters from './components/prospectosFilters/ProspectosFilters.vue'
import ProspectosTable from './components/prospectosTable/ProspectosTable.vue'
import { onMounted, watch } from 'vue'
import { useProspectosListStore } from './store/prospectosListStore'
import { useAlert } from '@/core/composables/useAlert'
import { useAppStore } from '@/core/store/appStore'
import { ProspectosListService } from './services/prospectosList-service'

const sessionStore = useSessionStore()
const appStore = useAppStore()
const store = useProspectosListStore()
const { close } = useAlert()

const exportToExcel = async (): Promise<void> => {
    const req = store.buildProspectosListApiRequest()
    await ProspectosListService.getProspectosListFromExcel(req)
}

watch(() => appStore.selectedRik, () => {
    //store.filters.rik = appStore.selectedRik

})

onMounted(async () => {
    try {
        await store.getProspectosListDebounce(true)
    } finally { close() }
})
</script>
