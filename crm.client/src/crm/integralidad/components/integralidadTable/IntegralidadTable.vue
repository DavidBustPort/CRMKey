<template>
    <div class="d-flex align-items-center mb-3">
        <FontAwesomeIcon icon="fa-list" class="me-2 text-muted" />
        <h5 class="mb-0 text-muted fw-semibold">Integralidades</h5>
    </div>
    <div class="row">
        <div class="col">
            <BaseTable
                class="mb-3 mb-md-0"
                :loading="store.isLoading"
                :colspan="13"
                :items="store.integralidadFiltrada"
                :pagination-config="store.pagination"
                @change:current-page="store.pagination.currentPage = $event"
                @change:set-items-per-page="($event: number) => store.setItemsPerPage($event)"
            >
                <template #header>
                    <th class="text-center">#</th>
                    <th>Cliente</th>
                    <th class="text-center" title="Tamaño del Cliente">Tam.</th>
                    <th>UEN / Segmento</th>
                    <th class="text-end">Venta</th>
                    <th class="text-end" title="Valor Potencial Teórico">VPT</th>
                    <th class="text-end" title="Valor Potencial Observado">VPO</th>
                    <th class="text-center" title="Porcentaje Cobertura VPT">% VPT</th>
                    <th class="text-center" title="Porcentaje Cobertura VPO">% VPO</th>
                    <th class="text-center" title="Integralidad de Aplicaciones">% Int.</th>
                    <th class="text-center" title="Potencial de Integralidad">% Pot.</th>
                    <th class="text-center">Acciones</th>
                </template>

                <template #row="{ item }">
                    <tr>
                        <td class="text-nowrap">
                            <button class="btn btn-link" @click="handleOpenOffcanvas(item)">
                                <FontAwesomeIcon icon="fa-chevron-right" size="xs" />
                            </button>
                            <span class="badge bg-light text-dark border">{{ item.clienteId }}</span>
                        </td>
                        <td>{{ item.cliente }}</td>
                        <td>{{ item.tamanoCliente }}</td>
                        <td>
                            <div class="small text-muted text-truncate" style="max-width: 150px;">
                                {{ item.uen }} <br>
                                <span class="text-lowercase">{{ item.segmento }}</span>
                            </div>
                        </td>
                        <td class="text-end text-success fw-semibold">{{ formatCurrency(item.ventas) }}</td>
                        <td class="text-end text-muted small">{{ formatCurrency(item.vpt) }}</td>
                        <td class="text-end text-muted small">{{ formatCurrency(item.vpo) }}</td>
                        <td class="text-center" style="width: 100px;">
                            <div class="progress" style="height: 6px;" v-tooltip="'Cobertura VPT'">
                                <div class="progress-bar bg-info" :style="{ width: item.porcentajeVpt + '%' }"></div>
                            </div>
                            <span class="x-small-text">{{ item.porcentajeVpt }}%</span>
                        </td>
                        <td class="text-center" style="width: 100px;">
                            <div class="progress" style="height: 6px;">
                                <div class="progress-bar bg-warning" :style="{ width: item.porcentajeVpo + '%' }"></div>
                            </div>
                            <span class="x-small-text">{{ item.porcentajeVpo }}%</span>
                        </td>
                        <td class="text-center">
                            <span :class="getStatusClass(item.porcentajeIntegralidadAplicaciones)" class="badge status-dot">
                                {{ item.porcentajeIntegralidadAplicaciones }}%
                            </span>
                        </td>
                        <td class="text-center">
                            <span class="text-primary fw-semibold">{{ item.porcentajePotencialIntegralidadAplicaciones }}%</span>
                        </td>
                        <td></td>
                    </tr>
                </template>
            </BaseTable>
        </div>
    </div>

    <CustomOffcanvas
        v-if="selectedCliente"
        :title="'Detalle del Cliente'"
        :isVisible="isClienteDetalleOpen"
        @close="isClienteDetalleOpen = false"
    >
        <IntegralidadTableClienteDetalle :cliente="selectedCliente" />
    </CustomOffcanvas>
</template>

<script setup lang="ts">
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import BaseTable from '@/shared/components/baseTable/BaseTable.vue'
import { useIntegralidadStore } from '../../store/integralidadStore'
import { ref } from 'vue'
import IntegralidadTableClienteDetalle from './IntegralidadTableClienteDetalle.vue'
import type { Integralidad } from '../../types/integralidad'
import CustomOffcanvas from '@/shared/components/CustomOffcanvas.vue'
import { formatCurrency } from '@/core/utils/numbers'

const store = useIntegralidadStore()

const isClienteDetalleOpen = ref<boolean>(false)
const selectedCliente = ref<Integralidad | null>(null)

const handleOpenOffcanvas = (item: Integralidad) => {
    selectedCliente.value = item
    isClienteDetalleOpen.value = true
}

const getStatusClass = (value: number) => {
    if (value >= 80) return 'bg-soft-success'
    if (value >= 50) return 'bg-soft-warning'
    return 'bg-soft-danger';
}
</script>

<style scoped>
thead th {
    text-transform: uppercase;
    font-size: 0.875em;
    font-weight: 600;
}

.status-dot {
    font-size: 0.85rem;
    padding: 0.4em 0.65em;
}

.bg-soft-success { background-color: #d1e7dd; color: #0f5132; }
.bg-soft-danger { background-color: #f8d7da; color: #842029; }
.bg-soft-warning { background-color: #fff3cd; color: #664d03; }

/* Efecto hover en las filas */
tr:hover {
    background-color: rgba(0,0,0,0.02);
    transition: background-color 0.2s ease;
}
</style>
