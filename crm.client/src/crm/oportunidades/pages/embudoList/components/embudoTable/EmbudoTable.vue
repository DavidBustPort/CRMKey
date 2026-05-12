<template>
    <div class="d-flex align-items-center mb-3">
        <FontAwesomeIcon icon="fa-list" class="me-2 text-muted" />
        <h5 class="mb-0 text-muted fw-semibold">Embudo</h5>
    </div>
    <div class="row">
        <div class="col">
            <BaseTable
                class="mb-3 mb-md-0"
                :colspan="14"
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
                    <th></th>
                </template>
                <template #row="{ item }">
                    <tr
                        :class="{ 'table-active fw-bold': isRowExpanded(item.oportunidadId) }">
                        <td>
                            <button class="btn btn-sm btn-outline-secondary me-2" @click.stop="toggleRow(item.oportunidadId)">
                                <FontAwesomeIcon :icon="['fas', isRowExpanded(item.oportunidadId) ? 'fa-minus' : 'fa-plus']" />
                            </button>
                            {{ item.oportunidadId }}
                        </td>
                        <td>{{ item.fuenteProspecto }}</td>
                        <td
                            class="text-truncate"
                            style="max-width: 150px;"
                            :title="item.cliente"
                        >{{ item.cliente}}</td>
                        <td
                            class="text-truncate"
                            style="max-width: 150px;"
                            :title="item.aplicacion"
                        >{{ item.aplicacion }}</td>
                        <td>
                            <VpoEdit
                                v-if="!sessionStore.isUserManager"
                                :oportunidad-id="item.oportunidadId"
                                :vpo="item.vpo"
                            />
                            <span v-else>{{ formatCurrency(item.vpo) }}</span>
                        </td>
                        <td>{{ item.vpt }}</td>
                        <td>{{ item.integralidad }}</td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td class="text-end">
                            <div class="d-flex justify-content-end gap-1">
                                <button class="btn btn-outline-primary btn-sm" title="Ir a Negociación">
                                    <FontAwesomeIcon icon="fa-comments" />
                                </button>

                                <ActionMenu :oportunidad="item" />
                            </div>
                        </td>
                    </tr>
                </template>

                <template #row-detail="{ item }">
                    <div v-if="expandedRowId === item.oportunidadId" class="border-top p-4 bg-light shadown-inner">
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <small class="text-muted">Cliente ID:</small>
                                <strong>{{ item.clienteId }} - {{ item.cliente }}</strong>
                            </div>
                        </div>
                    </div>
                </template>
            </BaseTable>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import BaseTable from '@/shared/components/baseTable/BaseTable.vue'
import { computed, ref, watch } from 'vue'
import { useEmbudoListStore } from '../../store/embudoListStore'
import ActionMenu from './actionMenu/ActionMenu.vue'
import VpoEdit from './vpoEdit/VpoEdit.vue'
import { useSessionStore } from '@/core/store/sessionStore'
import { formatCurrency } from '@/core/utils/numbers'

const store = useEmbudoListStore()
const sessionStore = useSessionStore()
const embudoList = computed(() => store.oportunidades.oportunidades)

const expandedRowId = ref<number | null>(null)

const toggleRow = (id: number) => {
    expandedRowId.value = expandedRowId.value === id ? null : id
}
const isRowExpanded = (id: number): boolean => expandedRowId.value === id

watch(() => store.pagination.currentPage, async () => {
    await store.getEmbudoListDebounce(false)
})
</script>
