<template>
    <div class="mb-2" :class="{ 'filter-disabled': props.loading }">
        <label for="uens" class="form-label" :class="{ 'fst-italic': props.labelItalics }">
            UEN
        </label>
        <select
            class="form-select p-2"
            id="uens"
            :disabled="props.loading"
            v-model.number="model"
        >
            <option :value="null">{{ props.title }}</option>
            <option v-for="uen in catalogsStore.uens" :key="uen.id" :value="uen.id">
                {{ uen.name }}
            </option>
        </select>
    </div>
</template>

<script lang="ts" setup>
import { onMounted } from 'vue'
import { useCatalogsStore } from '../store/catalogsStore'

interface Props {
    labelItalics?: boolean
    title?: string
    loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
    labelItalics: false,
    title: 'Todos',
    loading: false
})

const catalogsStore = useCatalogsStore()
const model = defineModel<number | null>()

onMounted(async () => await catalogsStore.fetchUens())
</script>
