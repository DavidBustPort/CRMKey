<template>
    <td v-for="(e, index) in etapas" :key="index">
        <div v-if="e.totalProyectos > 0" class="d-flex flex-column align-items-start">
            <span class="fw-bold">{{ e.totalProyectos }} proy.</span>
            <i>{{ formatCurrency(e.total ?? 0) }}</i>
        </div>
    </td>
</template>

<script lang="ts" setup>
import { formatCurrency } from '@/core/utils/numbers'
import type { Prospectos } from '../../types/prospectos'
import { ref } from 'vue'

const props = defineProps<{
    prospecto: Prospectos
}>()

interface Etapas {
    total: number
    totalProyectos: number
}

const etapas = ref<Etapas[]>([
    { total: props.prospecto.totalVpoAnalisis, totalProyectos: props.prospecto.totalOportunidadesAnalisis },
    { total: props.prospecto.totalVpoPromocion, totalProyectos: props.prospecto.totalOportunidadesPromocion },
    { total: props.prospecto.totalVpoNegociacion, totalProyectos: props.prospecto.totalOportunidadesNegociacion },
    { total: props.prospecto.totalVpoCierre, totalProyectos: props.prospecto.totalOportunidadesCierre }
])
</script>
