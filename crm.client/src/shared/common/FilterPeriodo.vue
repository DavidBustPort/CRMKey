<template>
    <div class="mb-2" :class="{ 'filter-disabled': props.loading }">
        <label
            class="form-label"
            :class="{ 'fst-italic': props.labelItalics }"
            for="mes-consulta"
        >{{ props.title ?? 'Periodo' }}</label>
        <VueDatePicker
            v-model="model"
            :formats="{
                input: 'MMMM yyyy',
                preview: '---'
            }"
            month-picker
            auto-apply
            :disabled="props.loading"
            :locale="es"
            :range="props.format === 'range'"
        />
    </div>
</template>

<script lang="ts" setup>
import { es } from 'date-fns/locale'

interface Props {
    format: 'range' | 'single'
    title?: string
    labelItalics?: boolean
    loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
    labelItalics: false,
    loading: false
})

const model = defineModel()
</script>

<style scoped>
:deep(.dp__input) {
    text-transform: capitalize;
    font-size: 0.875rem !important;
}

:deep(.dp__overlay_cell),
:deep(.dp__overlay_cell_active),
:deep(.dp__overlay_cell_pad) {
    text-transform: capitalize !important;
}
</style>
