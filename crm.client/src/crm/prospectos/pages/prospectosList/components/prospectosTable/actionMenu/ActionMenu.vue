<template>
    <div class="dropdown text-end">
        <button
            class="btn btn-link p-1 text-muted"
            type="button"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            aria-label="Opciones"
        >
            <FontAwesomeIcon icon="fa-ellipsis-vertical" />
        </button>
        <ul class="dropdown-menu">
            <li>
                <ActionMenuProspectoDetail />
            </li>
            <li>
                <RouterLink class="dropdown-item" :to="{ path: `/prospectos/editar/${props.prospectoId}` }">
                    <FontAwesomeIcon icon="fa-edit" class="me-2 text-muted" />
                    Editar prospecto
                </RouterLink>
            </li>
            <li>
                <RouterLink class="dropdown-item" :to="{ path: `/prospectos/editar/${props.prospectoId}` }">
                    <FontAwesomeIcon icon="fa-plus" class="me-2 text-muted" />
                    Agregar oportunidad
                </RouterLink>
            </li>
        </ul>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import ActionMenuProspectoDetail from './ActionMenuProspectoDetail.vue'

const props = defineProps<{
    prospectoId: number
}>()
</script>
