<template>
    <div class="mb-2" :class="{ 'filter-disabled': props.loading }">
        <label for="inputSearch" class="form-label" :class="{ 'fst-italic': props.labelItalics }">
            {{ props.label }}
        </label>
        <div class="input-group">
            <input
                type="text"
                class="form-control p-2"
                id="inputSearch"
                :disabled="props.loading"
                :placeholder="props.placeholder"
                :class="model ? 'select-highlighted' : 'select-default'"
                v-model="model"
            />
            <button
                type="button"
                :disabled="!model || props.loading"
                @click="model = ''"
                class="btn btn-outline-secondary"
                title="Limpiar"
            >
                <FontAwesomeIcon icon="fa-xmark" />
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

interface Props {
    label?: string
    labelItalics?: boolean
    placeholder?: string
    loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
    label: 'Nombre de ???',
    labelItalics: false,
    placeholder: 'Ej. Empresa S.A...',
    loading: false
})

const model = defineModel()
</script>
