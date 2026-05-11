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

        <div class="row align-items-end g-3 mt-1">
            <div class="col-12 col-md-3">
                <FilterByName
                    :label="'Nombre de cliente o prospecto'"
                    v-model="store.filters.byNombre"
                    :loading="store.isLoading"
                    :label-italics="true"
                />
            </div>
            <div class="col-12 col-md-3">
                <FilterPeriodo
                    :format="'single'"
                    :label-italics="true"
                    :loading="store.isLoading"
                    title="Periodo"
                    v-model="store.filters.date"
                />
            </div>
            <div class="col-12 col-md-3">
                <FilterEtapaProyecto
                    v-model="store.filters.byEtapa"
                    :loading="store.isLoading"
                    :label-italics="true"
                />
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import FilterByName from '@/shared/common/FilterByName.vue'
import { useEmbudoListStore } from '../../store/embudoListStore'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { computed, watch } from 'vue'
import FilterPeriodo from '@/shared/common/FilterPeriodo.vue'
import FilterEtapaProyecto from '@/shared/common/FilterEtapaProyecto.vue'

const store = useEmbudoListStore()

const hasActiveFilters = computed(() => {
    return Object.entries(store.filters).some(
        ([key, value]) =>
            value !== null &&
            key !== 'date' &&
            value !== ''
    )
})

watch(() => store.filters, () => store.getEmbudoListDebounce(false), {
    deep: true
})
</script>
