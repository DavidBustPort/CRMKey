<template>
    <div class="d-flex align-items-center mb-3">
        <FontAwesomeIcon icon="fa-list" class="me-2 text-muted" />
        <h5 class="mb-0 text-muted fw-semibold">Listado de prospectos</h5>
    </div>
    <div class="row">
        <div class="col">
            <BaseTable
                class="mb-3 mb-md-0"
                :loading="store.isLoading"
                :colspan="colspan"
                :items="prospectosList"
                :row-class="(item) => !item.estatusRegistro ? 'incomplete-row' : ''"
                :pagination-config="store.pagination"
                @change:current-page="store.pagination.currentPage = $event"
                @change:set-items-per-page="($event: number) => store.setItemsPerPage($event)"
            >
                <template #header>
                    <ProspectosTableThead @change-columns="colspan = $event" />
                </template>
                <template #row="{ item }">
                    <tr>
                        <td :title="!item.estatusRegistro ? 'Registro incompleto' : ''">
                            <span>{{ item.idProspecto }}</span>
                        </td>
                        <td>
                            <span v-if="store.filters.showManagerDetails">{{ truncate(item.prospecto, 20) }}</span>
                            <span v-else>{{ item.prospecto }}</span>
                        </td>
                        <td>{{ item.fuente }}</td>
                        <td class="text-end fw-bold">{{ formatCurrency(item.vpo) }}</td>
                        <td v-if="store.filters.showManagerDetails" :class="{ 'text-success': showManagerStatusClass(item)}">
                            {{  item.gte_EStatus }}
                        </td>
                        <td v-if="store.filters.showManagerDetails" :class="{ 'text-success': showRikStatusClass(item)}">
                            {{  item.rik_EStatus }}
                        </td>

                        <ProspectosTableTotalesByProyecto v-if="store.filters.showManagerDetails" :prospecto="item" />

                        <td :title="item.observaciones ?? ''">
                            {{ truncate(item.observaciones ?? '', store.filters.showManagerDetails ? 10 : 30) }}
                        </td>
                        <td>
                            <ActionMenu :prospecto-id="item.idProspecto" />
                        </td>
                    </tr>
                </template>
            </BaseTable>
        </div>
    </div>
</template>

<script lang="ts" setup>
import BaseTable from '@/shared/components/baseTable/BaseTable.vue'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { computed, ref, watch } from 'vue'
import { useProspectosListStore } from '../../store/prospectosListStore'
import { formatCurrency } from '@/core/utils/numbers'
import ProspectosTableThead from './ProspectosTableThead.vue'
import { truncate } from '@/core/utils/text'
import ActionMenu from './actionMenu/ActionMenu.vue'
import type { Prospectos } from '../../types/prospectos'
import ProspectosTableTotalesByProyecto from './ProspectosTableTotalesByProyecto.vue'

const store = useProspectosListStore()
const colspan = ref<number>(0)

const prospectosList = computed(() => store.prospectos.prospectos)

const showManagerStatusClass = (s: Prospectos): boolean => {
    return s.gte_EStatus === 'Enviado' && s.mkt_EStatus === 'Enviado' && s.rik_EStatus === 'No Procesado'
}

const showRikStatusClass = (s: Prospectos): boolean => {
    return s.gte_EStatus === 'Enviado' && s.mkt_EStatus === 'Enviado' && s.rik_EStatus === 'Procesado'
}

watch(() => store.pagination.currentPage, async () => {
    await store.getProspectosListDebounce(false)
})
</script>

<style scoped>
.incomplete-row {
    background: linear-gradient(90deg,
        rgba(255, 193, 7, 0.15) 0%,
        rgba(255, 193, 7, 0.05) 5%,
        transparent 15%
    ) !important;

    border-left: 4px solid #ffc107 !important;
    transition: background 0.3s ease;
}
</style>
