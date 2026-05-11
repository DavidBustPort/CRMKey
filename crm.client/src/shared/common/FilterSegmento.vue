<template>
    <div class="mb-2" :class="{ 'filter-disabled': props.loading }">
        <label for="segmentos" class="form-label" :class="{ 'fst-italic': props.labelItalics }">
            Segmentos
        </label>
        <select
            class="form-select p-2"
            id="segmentos"
            :disabled="props.loading"
            v-model.number="model"
        >
            id="segmentos"
            v-model.number="model"
        >
            <option disabled :value="null">{{ props.title }}</option>
            <option v-for="segmento in segmentos" :key="segmento.id" :value="segmento.id">
                {{ segmento.name }}
            </option>
        </select>
    </div>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue'
import { CatalogsService } from '../services/catalogs-service'
import type { Segmento } from '../types/catalogs'

interface Props {
    uenId: number | null
    labelItalics?: boolean
    title?: string
    resetValue?: boolean
    loading?: boolean
}


const props = withDefaults(defineProps<Props>(), {
    labelItalics: false,
    title: 'Todos',
    resetValue: true,
    loading: false
})

const segmentos = ref<Segmento[]>([])
const model = defineModel<number | null>()

watch(() => props.uenId, async (newValue) => {
    segmentos.value = []
    if (props.resetValue) model.value = null
    if (newValue && newValue !== -1) {
        segmentos.value = await CatalogsService.getSegmentos(newValue)
    }
}, { immediate: true })
</script>
