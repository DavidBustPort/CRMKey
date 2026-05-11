<template>
    <div class="border rounded shadow mb-4 p-4">
        <div class="d-flex justify-content-between mb-1 align-items-center">
            <div class="d-flex align-items-center mb-3">
                <FontAwesomeIcon icon="fa-filter" class="me-2 text-primary" />
                <h5 class="mb-0 fw-bold text-dark">Filtros de búsqueda</h5>
                <span v-if="hasActiveFilters" class="badge rounded-pill bg-primary-subtle text-primary ms-2 small">
                    Activos
                </span>
            </div>
            <button
                v-if="hasActiveFilters"
                title="Restablecer todos los filtros"
                @click="store.clearFilters"
                class="btn btn-link btn-sm text-danger text-decoration-none fw-bold"
            >
                <FontAwesomeIcon icon="fa-trash-can" class="me-1" />
                Limpiar todo
            </button>
        </div>
        <hr class="opacity-10 mb-3 mt-0">

        <ProspectosFiltersByEvolucionEtapas v-if="sessionStore.isUserManager" />

        <div class="row align-items-end g-3 mt-1">
            <div class="col-12 col-md-3">
                <FilterPeriodo
                    :format="'single'"
                    :label-italics="true"
                    :loading="store.isLoading"
                    title="Periodo de registro"
                    v-model="store.filters.date"
                />
            </div>
            <div class="col-12 col-md-3">
                <ProspectosFiltersByNombre />
            </div>
            <div class="col-12 col-md-3">
                <FilterTipoProspecto
                    :label-italics="true"
                    :loading="store.isLoading"
                    v-model="store.filters.byTipoProspecto"
                />
            </div>
            <div class="col-12 col-md-3">
                <ProspectosFiltersByRegistro />
            </div>
            <div class="col-md-3">
                <ProspectosFiltersByEstatus />
            </div>
            <div class="col-md-3" v-if="store.filters.showManagerDetails">
                <ProspectosFiltersByEtapaLead />
            </div>
            <div class="col-md-3" v-if="store.filters.showManagerDetails">
                <FilterEtapaProyecto
                    :label-italics="true"
                    :loading="store.isLoading"
                    v-model="store.filters.byEtapaProyecto"
                />
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { computed, watch } from 'vue'
import { useProspectosListStore } from '../../store/prospectosListStore'
import FilterPeriodo from '@/shared/common/FilterPeriodo.vue'
import ProspectosFiltersByNombre from './ProspectosFiltersByNombre.vue'
import FilterTipoProspecto from '@/shared/common/FilterTipoProspecto.vue'
import ProspectosFiltersByRegistro from './ProspectosFiltersByRegistro.vue'
import ProspectosFiltersByEstatus from './ProspectosFiltersByEstatus.vue'
import ProspectosFiltersByEtapaLead from './ProspectosFiltersByEtapaLead.vue'
import ProspectosFiltersByEvolucionEtapas from './ProspectosFiltersByEvolucionEtapas.vue'
import { useSessionStore } from '@/core/store/sessionStore'
import FilterEtapaProyecto from '@/shared/common/FilterEtapaProyecto.vue'

const store = useProspectosListStore()
const sessionStore = useSessionStore()

const hasActiveFilters = computed(() => {
    return Object.entries(store.filters).some(
        ([key, value]) =>
            value !== null &&
            key !== 'rik' &&
            value !== '' &&
            key !== 'showManagerDetails'
    )
})

watch(() => store.filters, () => store.getProspectosListDebounce(false), {
    deep: true
})
</script>
