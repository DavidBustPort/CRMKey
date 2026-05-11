<template>
    <div class="row mb-3">
        <div class="col-12 text-center text-md-start col-md-6">
            <h2 class="text-primary fw-bold ps-3 border-start border-4 border-primary">Embudo de oportunidades</h2>
        </div>
    </div>
    <div class="card">
        <div class="card-body">
            <EmbudoFilters />
            <hr class="my-4 hr-table">
            <EmbudoTable />
        </div>
    </div>
</template>

<script lang="ts" setup>
import EmbudoTable from './components/embudoTable/EmbudoTable.vue'
import { onMounted } from 'vue'
import { useAlert } from '@/core/composables/useAlert'
import { useEmbudoListStore } from './store/embudoListStore'
import EmbudoFilters from './components/embudoFilters/EmbudoFilters.vue'

const store = useEmbudoListStore()
const { close } = useAlert()

onMounted(async () => {
    try {
        await store.getEmbudoListDebounce(true)
    } finally { close() }
})
</script>
