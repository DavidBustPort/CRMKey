<template>
    <div class="border rounded shadow-sm mb-4 p-4 bg-white">
        <div class="d-flex align-items-center mb-4">
            <FontAwesomeIcon icon="fa-filter" class="me-2 text-primary" />
            <h5 class="mb-0 fw-bold text-dark">Filtros de búsqueda</h5>
        </div>

        <div class="row g-4">
            <div class="col-12 col-lg-9">
                <div class="p-3 rounded border border-light-subtle h-100">
                    <div class="d-flex justify-content-between align-items-center mb-3">
                        <span class="text-bg-primary-soft fw-bold">
                            CONFIGURACIÓN DE BÚSQUEDA
                        </span>
                        <button
                            class="btn btn-primary btn-sm px-4 shadow-sm"
                            @click="handleFetchData"
                            :disabled="store.isLoading"
                        >
                            <FontAwesomeIcon
                                :icon="store.isLoading ? 'fa-spinner' : 'fa-search'"
                                :spin="store.isLoading"
                                class="me-2" />
                                {{ store.isLoading ? 'Consultando...' : 'Consultar' }}
                        </button>
                    </div>

                    <div class="row g-3">
                        <div class="col-12 col-md-4">
                            <FilterPeriodo
                                :format="'single'"
                                :label-italics="true"
                                :loading="store.isLoading"
                                title="Periodo de registro"
                                v-model="store.filters.date"
                            />
                        </div>
                        <div class="col-12 col-md-4">
                            <FilterUEN :label-italics="true" :loading="store.isLoading" v-model="store.filters.uen" />
                        </div>
                        <div class="col-12 col-md-4">
                            <FilterSegmento
                                :label-italics="true"
                                :uen-id="store.filters.uen"
                                :loading="store.isLoading"
                                v-model="store.filters.segmento"
                            />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-12 col-lg-3">
                <div class="p-3 border rounded h-100 border-dashed">
                    <small class="text-muted fw-bold text-uppercase d-block mb-3" style="font-size: 0.75rem;">
                        Filtrar Clientes
                    </small>
                    <div :class="{ 'opacity-50 pointer-events-none': !store.integralidadList.length }">
                        <IntegralidadFiltersClientes />
                        <p v-if="!store.integralidadList.length" class="text-muted small mt-2 mb-0 fst-italic">
                            Realice una consulta para ver clientes.
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { useIntegralidadStore } from '../../store/integralidadStore'
import FilterPeriodo from '@/shared/common/FilterPeriodo.vue'
import FilterUEN from '@/shared/common/FilterUEN.vue'
import FilterSegmento from '@/shared/common/FilterSegmento.vue'
import IntegralidadFiltersClientes from './IntegralidadFiltersClientes.vue'

const store = useIntegralidadStore()

const handleFetchData = async () => {
    store.filters.cliente = null
    await store.getIntegralidadData()
}
</script>

<style scoped>
.border-dashed {
    border-style: dashed !important;
    border-width: 2px;
}
.pointer-events-none {
    pointer-events: none;
}
.border-primary {
    border-color: #0d6efd !important;
}
</style>
