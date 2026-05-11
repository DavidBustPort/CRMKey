<template>
    <div class="mb-2" :class="{ 'filter-disabled': store.isLoading }">
        <label for="registro" class="form-label fst-italic">
            Registro
        </label>
        <select
            v-model.number="store.filters.byRegistro"
            class="form-select p-2"
            id="registro"
            :disabled="store.isLoading"
        >
            <option :value="null">Todos</option>
            <option :value="RegistroProspecto.COMPLETO">Completo</option>
            <option :value="RegistroProspecto.INCOMPLETO">Incompleto</option>
        </select>
    </div>
</template>

<script lang="ts" setup>
import { useProspectosListStore } from '../../store/prospectosListStore'
import { RegistroProspecto } from '../../store/types'

const store = useProspectosListStore()
</script>
