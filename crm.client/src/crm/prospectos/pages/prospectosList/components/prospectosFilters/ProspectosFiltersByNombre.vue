<template>
    <div class="mb-2" :class="{ 'filter-disabled': store.isLoading }">
        <label for="prospecto" class="form-label fst-italic">
            Nombre de prospecto
        </label>
        <div class="input-group">
            <input
                type="text"
                class="form-control p-2"
                id="prospecto"
                :disabled="store.isLoading"
                placeholder="Ej. Empresa S.A..."
                :class="name ? 'select-highlighted' : 'select-default'"
                v-model="name"
            />
            <button
                type="button"
                :disabled="!name"
                @click="name = ''"
                class="btn btn-outline-secondary"
                title="Limpiar"
            >
                <FontAwesomeIcon icon="fa-xmark" />
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { useProspectosListStore } from '../../store/prospectosListStore'

const store = useProspectosListStore()
const name = computed({
    get: () => store.filters.byNombre,
    set: (value: string) => {
        store.filters.byNombre = value
    }
})
</script>
