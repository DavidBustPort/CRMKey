<template>
    <DashboardFilters />
    <TotalesPorEtapas />
	<div class="row mt-4 align-items-stretch">
        <div class="col-12 col-lg-7">
            <h1>hola</h1>
        </div>
    </div>
    <ScrollToTopButton />
</template>

<script lang="ts" setup>
import { onMounted } from 'vue'
import { useDashboardStore } from './store/dashboardStore'
import ScrollToTopButton from '@/shared/components/ScrollToTopButton.vue'
import DashboardFilters from './components/dashboardFilters/DashboardFilters.vue'
import TotalesPorEtapas from './components/TotalesPorEtapas.vue'

const store = useDashboardStore()

onMounted(async () => {
    try {
        await store.fetch()
    } finally {}
})
</script>
