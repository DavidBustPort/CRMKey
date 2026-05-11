<template>
    <tr class="bg-light">
        <td :colspan="props.colspan" class="text-center py-4 text-muted">
            <FontAwesomeIcon icon="fa-inbox" class="me-2" />
            <span class="text-muted">{{ props.message || 'No hay datos disponibles' }}</span>
        </td>
    </tr>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

const props = defineProps<{
    colspan: number
    message?: string
}>()
</script>
