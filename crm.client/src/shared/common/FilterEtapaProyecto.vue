<template>
    <div class="mb-2" :class="{ 'filter-disabled': props.loading }">
        <label for="etapaProyectos" class="form-label" :class="{ 'fst-italic': props.labelItalics }">
            Etapas de proyectos
        </label>
        <select
            v-model.number="model"
            :disabled="props.loading"
            class="form-select p-2"
            id="etapaProyectos"
        >
            <option :value="null">Todos</option>
            <option v-for="etapa in etapasOptions" :key="etapa.value" :value="etapa.value">
                {{ etapa.label }}
            </option>
        </select>
    </div>
</template>

<script lang="ts" setup>
import { computed } from 'vue'
import { EtapasOportunidadesName, EtapasOportunidadesAbbreviation, EtapasOportunidades} from '../types/etapasOportunidades'

interface Props {
    labelItalics?: boolean
    showCancelled?: boolean
    loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
    labelItalics: false,
    loading: false
})

const etapasOptions = computed(() => {
    return Object.values(EtapasOportunidades).map((value) => {
        return {
            label: `${EtapasOportunidadesAbbreviation[value]} (${EtapasOportunidadesName[value]})`,
            value: value
        }
    }).filter(option => {
        if (!props.showCancelled && option.value === EtapasOportunidades.CANCELADA) {
            return false
        }
        return true
    })
})

const model = defineModel()
</script>
