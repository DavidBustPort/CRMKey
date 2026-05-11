<template>
    <template v-for="(col, index) in columns" :key="index">
        <th
            class="text-uppercase small fw-bold"
            v-if="col.show"
            scope="col"
            :class="col.class"
        >{{ col.name }}</th>
    </template>
</template>

<script lang="ts" setup>
import { watch, computed } from 'vue'
import { useProspectosListStore } from '../../store/prospectosListStore'

const emit = defineEmits<{ changeColumns: [length: number] }>()

interface DetailTableColumns {
    name: string,
    show: boolean,
    class?: string
}

const store = useProspectosListStore()
const columns = computed<DetailTableColumns[]>(() => [
    { name: 'Prospecto Id', show: true },
    { name: 'Prospecto', show: true },
    { name: 'Fuente', show: true },
    { name: 'VPO', show: true, class: 'text-end' },
    { name: 'GTE-RIK', show: store.filters.showManagerDetails },
    { name: 'RIK', show: store.filters.showManagerDetails },
    { name: 'A', show: store.filters.showManagerDetails, class: 'text-center etapa-a text-white' },
    { name: 'P', show: store.filters.showManagerDetails, class: 'text-center etapa-p text-white' },
    { name: 'N', show: store.filters.showManagerDetails, class: 'text-center etapa-n text-white' },
    { name: 'C', show: store.filters.showManagerDetails, class: 'text-center etapa-c text-white' },
    { name: 'Observaciones', show: true },
    //{ name: 'Fecha registro', show: true },
    { name: '', show: true }
])

watch(columns, (newColumns) => {
    emit('changeColumns', newColumns.filter(x => x.show).length)
}, { immediate: true })
</script>
