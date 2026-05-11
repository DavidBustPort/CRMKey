<template>
    <div class="row">
        <div class="col">
            <div class="d-flex align-items-center">
                <input
                    type="checkbox"
                    class="d-none"
                    id="detalle-checkbox"
                    v-model="store.filters.showManagerDetails"
                >
                <label for="detalle-checkbox" class="d-flex align-items-center cursor-pointer mb-0">
                    <FontAwesomeIcon
                        icon="fa-square-check"
                        :class="store.filters.showManagerDetails ? 'text-success' : 'text-secondary'"
                        class="fa-2x"
                    />
                    <span class="ms-2">Con detalle</span>
                </label>
            </div>
            <small class="d-block mt-1">Incluye evolución de etapas para Leads.</small>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { useProspectosListStore } from '../../store/prospectosListStore'

const store = useProspectosListStore()
</script>
