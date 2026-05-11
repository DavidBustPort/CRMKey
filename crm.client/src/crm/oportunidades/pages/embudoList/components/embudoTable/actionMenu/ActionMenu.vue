<template>
    <div class="dropdown text-end">
        <button
            class="btn btn-link p-1 text-muted"
            type="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            aria-label="Opciones"
        >
            <FontAwesomeIcon icon="fa-ellipsis-v" />
        </button>
        <ul class="dropdown-menu dropdown-menu-end shadow-sm">
            <li>
                <RouterLink class="dropdown-item" :to="{ path: `/prospectos/editar/` }">
                    <FontAwesomeIcon :icon="['fas', 'edit']" class="me-2 text-muted" />
                    Editar oportunidad
                </RouterLink>
            </li>
            <li><hr class="dropdown-divider"></li>

            <li v-if="props.oportunidad?.etapa !== EtapasOportunidades.CANCELADA">
                <CancelarOportunidad :oportunidad-id="props.oportunidad?.oportunidadId" />
            </li>
        </ul>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import type { Embudo } from '../../../types/oportunidades'
import { EtapasOportunidades } from '@/shared/types/etapasOportunidades'
import CancelarOportunidad from './cancelarOportunidad/CancelarOportunidad.vue'

const props = defineProps<{
    oportunidad: Embudo
}>()
</script>
