<template>
    <div class="mb-2" :class="{ 'filter-disabled': store.isLoading }">
        <label for="estatus-prospecto" class="form-label fst-italic">
            Estatus prospecto
        </label>
        <select
            v-model.number="store.filters.byEstatus"
            :disabled="store.isLoading"
            class="form-select p-2"
            id="estatus-prospecto"
        >
            <option :value="null">Todos</option>
            <option :value="EstatusProspecto.ABIERTO">Abierto</option>
            <option :value="EstatusProspecto.CERRADO">Cerrado</option>
        </select>
    </div>
</template>

<script lang="ts" setup>
import { useProspectosListStore } from '../../store/prospectosListStore'
import { EstatusProspecto } from '@/shared/types/estatusProspecto'

const store = useProspectosListStore()
</script>
