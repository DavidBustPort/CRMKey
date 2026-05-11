<template>
    <div class="mb-2" :class="{ 'filter-disabled': store.isLoading }">
        <label for="estatus-prospecto" class="form-label fst-italic">Clientes</label>
        <Select
            id="estatus-prospecto"
            v-model="store.filters.cliente"
            :options="clientes"
            filter
            :disabled="store.isLoading"
            ref="selectRef"
            option-label="name"
            option-value="id"
            class="bootstrap-style-select"
            placeholder="Todos"
            :show-clear="true"
            @change="onChange"
        />
    </div>
</template>

<script lang="ts" setup>
import { computed, ref, nextTick } from 'vue'
import { useIntegralidadStore } from '../../store/integralidadStore'
import type { Catalogs } from '@/shared/types/catalogs'
import Select, { type SelectChangeEvent } from 'primevue/select'

const store = useIntegralidadStore()

const selectRef = ref<InstanceType<typeof Select> | null>(null)

const clientes = computed<Catalogs[]>(() => {
    const map = new Map()
    store.integralidadList.forEach(item => {
        if (!map.has(item.clienteId)) {
            map.set(item.clienteId, {
                id: item.clienteId,
                name: `${item.clienteId} - ${item.cliente}`
            })
        }
    })
    return Array.from(map.values())
})

const onChange = async (event: SelectChangeEvent) => {
    store.resetPaging()
    if (event.value === null) {
        await nextTick()

        if (selectRef.value) {
            selectRef.value.hide()
        }
    }
}
</script>

<style scoped>
.custom-dropdown-container {
    max-width: 300px;
    font-size: 0.875rem !important;
}
:deep(.bootstrap-style-select) {
    width: 100%;
    height: 38px;
    background-color: #fff;
    border: 1px solid #dee2e6;
    border-radius: 0.375rem;
    font-size: 0.875rem;
    display: flex;
    align-items: center;
    transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}
:deep(.bootstrap-style-select:not(.p-disabled).p-focus) {
    border-color: #86b7fe;
    outline: 0;
    box-shadow: 0 0 0 0.25rem rgba(13, 110, 253, 0.25);
}
:deep(.p-select-label) {
    padding: 0.375rem 0.75rem;
    font-size: 0.875rem;
    color: #212529;
}
:deep(.p-select-trigger) {
    width: 2.5rem;
}
:deep(.p-select-clear-icon) {
    right: 2.5rem;
}
</style>
