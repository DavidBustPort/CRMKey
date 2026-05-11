<template>
    <div class="mb-2" :class="{ 'filter-disabled': props.loading }">
        <label for="tipo-prospecto" class="form-label" :class="{ 'fst-italic': props.labelItalics }">
            Tipo de prospecto
        </label>
        <select
            class="form-select p-2"
            id="tipo-prospecto"
            v-model="model"
            :disabled="props.loading"
        >
            <option
                v-for="(option, index) in tipoProspectoOptions"
                :key="index"
                :value="option.value"
            >
                {{ option.label }}
            </option>
        </select>
    </div>
</template>

<script lang="ts" setup>
import type { TipoProspecto } from '../types/tipoProspecto'

interface Props {
    labelItalics?: boolean
    loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
    labelItalics: false,
    loading: false
})

interface TipoProspectoOption {
    label: string
    value: TipoProspecto | null
}

const tipoProspectoOptions: TipoProspectoOption[] = [
    { label: 'Todos', value: null },
    { label: 'TD (Tradicional)', value: 'TD' },
    { label: 'LD (Leads)', value: 'LD' }
]

const model = defineModel()
</script>
