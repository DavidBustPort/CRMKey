<template>
    <div class="row mb-3">
        <div class="col-12 text-center text-md-start col-md-6">
            <h2 class="text-primary fw-bold ps-3 border-start border-4 border-primary">Integralidad</h2>
        </div>
        <div class="col-12 col-md-6 mt-3 mt-md-0 text-end">

        </div>
    </div>
    <div class="card">
        <div class="card-body">
            <IntegralidadFilters />
            <hr class="my-4 hr-table">
            <IntegralidadTable />
        </div>
    </div>
</template>

<script setup lang="ts">
import { onMounted } from 'vue'
import IntegralidadFilters from './components/integralidadFilters/IntegralidadFilters.vue'
import IntegralidadTable from './components/integralidadTable/IntegralidadTable.vue'
import { useIntegralidadStore } from './store/integralidadStore'

const store = useIntegralidadStore()

onMounted(async () => await store.getIntegralidadData())
</script>
