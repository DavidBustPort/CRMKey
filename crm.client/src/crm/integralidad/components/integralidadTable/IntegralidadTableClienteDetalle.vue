<template>
    <div class="mb-4 border-bottom pb-3">
        <span class="text-muted small text-uppercase ls-wide">Expediente del Cliente</span>
        <h2 class="fw-light text-dark m-0">{{ mockCliente.cliente }}</h2>
        <div class="d-flex gap-3 mt-2 text-muted small">
            <span><strong>ID:</strong> {{ mockCliente.clienteId }}</span>
            <span>|</span>
            <span><strong>UEN:</strong> {{ mockCliente.uen }}</span>
        </div>
    </div>

    <div class="row g-3 mb-4">
        <div class="col-md-6">
            <div class="border rounded p-3 bg-white shadow-sm">
                <div class="d-flex justify-content-between align-items-center">
                    <span class="text-secondary small fw-bold">VENTA TOTAL</span>
                    <i class="bi bi-cash-stack text-muted"></i>
                </div>
                <div class="h3 mb-0 text-dark">{{ currency(mockCliente.ventas) }}</div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="border rounded p-3 bg-white shadow-sm">
                <div class="d-flex justify-content-between align-items-center">
                    <span class="text-secondary small fw-bold">INTEGRALIDAD</span>
                    <i class="bi bi-pie-chart text-muted"></i>
                </div>
                <div class="h3 mb-0 text-dark">{{ percent(mockCliente.porcentajeIntegralidadAplicaciones) }}</div>
            </div>
        </div>
    </div>

    <ul class="nav nav-tabs mb-3" id="detalleTab" role="tablist">
        <li class="nav-item">
            <button class="nav-link active text-dark" data-bs-toggle="tab" data-bs-target="#tab-resumen" type="button">
                Resumen
            </button>
        </li>
        <li class="nav-item">
            <button class="nav-link text-dark" data-bs-toggle="tab" data-bs-target="#tab-vende" type="button">
                Vende ({{ aplicacionesVende.length }})
            </button>
        </li>
        <li class="nav-item">
            <button class="nav-link text-dark" data-bs-toggle="tab" data-bs-target="#tab-no-vende" type="button">
                No Vende ({{ aplicacionesNoVende.length }})
            </button>
        </li>
    </ul>

    <div class="tab-content pt-2">
        <div class="tab-pane fade show active" id="tab-resumen">
            <div class="row">
                <div class="col-md-8">
                    <p class="text-muted small mb-4">Distribución de ventas por categoría de aplicación.</p>
                    <div v-for="cat in mockCliente.clienteDetalle.ventaPorCategoria" :key="cat.categoria" class="mb-3">
                        <div class="d-flex justify-content-between mb-1">
                            <span class="small text-uppercase text-secondary">{{ cat.categoria }}</span>
                            <span class="small fw-bold">{{ percent(cat.porcentaje) }}</span>
                        </div>
                        <div class="progress" style="height: 6px; background-color: #f0f0f0;">
                            <div class="progress-bar bg-dark" :style="{ width: percent(cat.porcentaje) }"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="tab-pane fade" id="tab-vende">
            <div class="table-responsive">
                <table class="table table-sm border-top">
                    <thead>
                        <tr class="text-muted small bg-light">
                            <th class="py-2">APLICACIÓN</th>
                            <th class="text-end py-2">VENTA</th>
                            <th class="text-end py-2">% INTEGRALIDAD</th>
                        </tr>
                    </thead>
                    <tbody class="small">
                        <tr v-for="(app, index) in aplicacionesVende" :key="index">
                            <td class="py-2">{{ app.aplicacion }}</td>
                            <td class="text-end py-2 fw-medium">{{ currency(app.venta) }}</td>
                            <td class="text-end py-2 text-muted">{{ percent(app.porcentajeIntegralidad) }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <div class="tab-pane fade" id="tab-no-vende">
            <div class="table-responsive">
                <table class="table table-sm border-top">
                    <thead>
                        <tr class="text-muted small bg-light">
                            <th class="py-2">APLICACIÓN</th>
                            <th class="text-end py-2 text-danger">POTENCIAL TEÓRICO</th>
                        </tr>
                    </thead>
                    <tbody class="small">
                        <tr v-for="(app, index) in aplicacionesNoVende" :key="index">
                            <td class="py-2 text-muted">{{ app.aplicacion }}</td>
                            <td class="text-end py-2 text-danger fw-bold">{{ percent(app.porcentajeIntegralidad) }}</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { computed } from 'vue'
import type { Aplicaciones, Integralidad } from '../../types/integralidad'

// MOCK DATA: Esto es lo que verás mientras refactorizas el servicio
const mockCliente = {
    clienteId: 3814,
    cliente: "OPERADORA HOTELERA DE ANAHUAC",
    uen: "Hoteles - Institucional Especializada",
    ventas: 24910.92,
    porcentajeIntegralidadAplicaciones: 87.5,
    clienteDetalle: {
        ventaPorCategoria: [
            { categoria: "PAPEL", porcentaje: 40.2 },
            { categoria: "QUIMICOS", porcentaje: 57.8 },
            { categoria: "SUPLEMENTOS", porcentaje: 2.0 }
        ],
        aplicacionesVendidas: [
            { aplicacion: "01. QUIMICOS DE ASEO", venta: 12022.20, porcentajeIntegralidad: 8.0 },
            { aplicacion: "05. HIGIENE DE MANOS", venta: 5430.00, porcentajeIntegralidad: 12.5 },
            { aplicacion: "08. ACCESORIOS DE PAPEL", venta: 7458.72, porcentajeIntegralidad: 67.0 }
        ],
        aplicacionesNoVendidas: [
            { aplicacion: "31. SUPLEMENTOS ESPECIALIZADOS", porcentajeIntegralidad: 3.0 },
            { aplicacion: "12. DESINFECTANTES", porcentajeIntegralidad: 11.0 }
        ]
    }
}

// Props (se mantienen para cuando conectes la data real)
const props = defineProps<{ cliente: Integralidad }>()

// Formateadores
const currency = (val: number) =>
    new Intl.NumberFormat('es-MX', { style: 'currency', currency: 'MXN' }).format(val)

const percent = (val: number) => `${(val || 0).toFixed(1)}%`

const aplicacionesVende = computed<Aplicaciones[]>(() => props.cliente?.clienteDetalle?.aplicacionesVendidas || [])
const aplicacionesNoVende = computed(() => mockCliente.clienteDetalle.aplicacionesNoVendidas)

</script>

<style scoped>
.ls-wide { letter-spacing: 0.05em; }
.nav-tabs .nav-link {
    border: none;
    border-bottom: 2px solid transparent;
    transition: all 0.2s ease;
}
.nav-tabs .nav-link.active {
    border-bottom: 2px solid #212529;
    font-weight: 600;
}
.nav-tabs .nav-link:hover:not(.active) {
    border-bottom: 2px solid #dee2e6;
}
.progress-bar {
    transition: width 0.6s ease;
}
</style>
