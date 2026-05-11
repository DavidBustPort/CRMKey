<template>
    <div class="d-flex align-items-center mb-3">
        <FontAwesomeIcon icon="fa-list" class="me-2 text-muted" />
        <h5 class="mb-0 text-muted fw-semibold">Embudo</h5>
    </div>
    <div class="row">
        <div class="col">
            <BaseTable
                class="mb-3 mb-md-0"
                :colspan="7"
                :loading="store.isLoading"
                :items="embudoList"
                :pagination-config="store.pagination"
                @change:current-page="store.pagination.currentPage = $event"
                @change:set-items-per-page="($event: number) => store.setItemsPerPage($event)"
            >
                <template #header>
                    <th># Oportunidad</th>
                    <th>Fuente</th>
                    <th>Cliente/Prospecto</th>
                    <th>Aplicación</th>
                    <th>VPO</th>
                    <th>VPT</th>
                    <th>Integralidad</th>
                    <th class="etapa-a text-white text-center">A</th>
                    <th class="etapa-p text-white text-center">P</th>
                    <th class="etapa-n text-white text-center">N</th>
                    <th class="etapa-c text-white text-center">C</th>
                    <th>Acys</th>
                    <th>Facturación</th>
                </template>
                <template #row="{ item }">
                    <tr>
                        <td>{{ item.oportunidadId }}</td>
                        <td>{{ item.fuenteProspecto }}</td>
                        <td>{{ item.cliente }}</td>
                        <td>{{ item.aplicacion }}</td>
                        <td>{{ item.vpo }}</td>
                        <td>{{ item.vpt }}</td>
                        <td>{{ item.integralidad }}</td>
                    </tr>
                </template>
            </BaseTable>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import BaseTable from '@/shared/components/baseTable/BaseTable.vue'
import { computed } from 'vue'
import { useEmbudoListStore } from '../../store/embudoListStore'

const store = useEmbudoListStore()
const embudoList = computed(() => store.oportunidades.oportunidades)
</script>
