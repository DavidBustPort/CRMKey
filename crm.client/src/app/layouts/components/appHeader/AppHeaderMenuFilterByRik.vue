<template>
    <li class="nav-item dropdown">
        <a href="" role="button" class="nav-link dropdown-toggle d-none d-sm-inline-block" data-bs-toggle="dropdown" aria-expanded="false">
            <span class="me-2">Riks:</span>
            <strong class="text-danger">{{ selectedRikName }}</strong>
        </a>
        <div class="dropdown-menu dropdown-menu-end rik-gerente-dropdown">
            <div class="dropdown-header d-flex align-items-center">
                <FontAwesomeIcon :icon="['fas', 'user-tie']" class="me-2 text-primary" />
                <strong>Ejecutivos de Ventas</strong>
            </div>
            <div class="dropdown-divider"></div>
            <div class="search-container mb-3">
                <div class="input-group">
                    <span class="input-group-text">
                        <FontAwesomeIcon :icon="['fas', 'search']" class="text-muted" />
                    </span>
                    <input
                        v-model="searchTerm"
                        type="text"
                        class="form-control"
                        placeholder="Buscar ejecutivo..."
                        @click.stop
                    >
                </div>
            </div>
            <div v-for="(rik, index) in filteredRiks" :key="index">
                <button
                    class="dropdown-item rik-option"
                    @click="selectRik(rik)"
                    :class="{ 'active': selectedRik?.id === rik.id }"
                >
                    <div class="d-flex align-items-center">
                        <FontAwesomeIcon :icon="['fas', 'users']" v-if="rik.id === null" />
                        <div class="rik-option-name">
                            <span v-if="rik.id !== null">
                                <strong>{{ rik.id }}</strong> - {{ rik.name }}
                            </span>
                            <span v-else class="ms-3">{{ rik.name }}</span>
                        </div>
                        <div class="rik-option-status ms-3">
                            <FontAwesomeIcon :icon="['fas', 'check']" v-if="selectedRik?.id === rik.id" />
                        </div>
                    </div>
                </button>
            </div>
        </div>
    </li>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { computed, onMounted, ref } from 'vue'
import { useCatalogsStore } from '@/shared/store/catalogsStore'

interface RikList {
    id: number | null
    name: string
}

const catalogsStore = useCatalogsStore()
const riks = ref<RikList[]>([])
const selectedRik = ref<RikList>()
const searchTerm = ref<string>('')

const selectRik = (rik: RikList) => {
    selectedRik.value = rik
    searchTerm.value = ''
}

const selectedRikName = computed(() => {
    return selectedRik.value?.id
    ? `${selectedRik.value?.id} - ${selectedRik.value?.name}`
    : selectedRik.value?.name
})

const filteredRiks = computed(() => {
    if (!searchTerm.value) return riks.value
    return riks.value.filter(r => r.name.toLowerCase().includes(searchTerm.value.toLowerCase()))
})

onMounted(async () => {
    await catalogsStore.fetchRiks()
    riks.value.push(...catalogsStore.riks)

    riks.value.unshift({
        id: null,
        name: 'Todos los Riks'
    })
    selectedRik.value = riks.value[0]
})
</script>
