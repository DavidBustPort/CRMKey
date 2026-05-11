<template>
    <div :class="{ 'table-responsive': isMobile }" ref="tableContainer">
        <table class="table align-middle table-hover">
            <thead class="table-light">
                <tr>
                    <slot name="header" />
                </tr>
            </thead>
            <tbody :class="{ 'table-loading-overlay': props.loading }">
                <tr v-if="props.loading" class="progress-row">
                    <td :colspan="props.colspan" class="p-0 border-0">
                        <div class="progress custom-progress">
                            <div class="progress-bar progress-bar-animated progress-bar-striped w-100"></div>
                        </div>
                    </td>
                </tr>

                <LoadingTable
                    v-if="props.loading && items.length === 0"
                    class="progress-row"
                    :colspan="props.colspan"
                />

                <template v-if="props.items.length > 0">
                    <template v-for="(item) in props.items">
                        <slot name="row" :item="item" />
                    </template>
                </template>

                <NoRowsTable
                    v-else-if="!props.loading && items.length === 0"
                    class="progress-row"
                    :colspan="props.colspan" />
            </tbody>
        </table>
        <CustomPagination
            v-if="props.paginationConfig && props.paginationConfig.totalRows > 0"
            :config="props.paginationConfig"
            @change:current-page="$emit('change:current-page', $event)"
            @change:set-items-per-page="$emit('change:set-items-per-page', $event)"
        />
    </div>
</template>

<script lang="ts" setup generic="T">
import { useResize } from '@/core/composables/useResize'
import LoadingTable from '../LoadingTable.vue'
import NoRowsTable from '../NoRowsTable.vue'
import CustomPagination from '../customPagination/CustomPagination.vue'
import type { Pagination } from '../customPagination/types'
import { nextTick, ref, watch } from 'vue'

interface Props {
    items: T[]
    loading: boolean
    colspan: number,
    rowClass?: (item: T) => string,
    paginationConfig?: Pagination
}

const props = defineProps<Props>()

const { isMobile } = useResize()
const tableContainer = ref<HTMLElement | null>(null)
const isFirstLoad = ref<boolean>(true)

const scrollToTable = () => {
    if (tableContainer.value) {
        tableContainer.value.scrollIntoView({
            behavior: 'smooth'
        })
    }
}

watch(() => props.items, async (newItems) => {
    if (isFirstLoad.value) {
        isFirstLoad.value = false
        return
    }

    if (newItems && newItems.length > 0) {
        await nextTick()
        scrollToTable()
    }
}, { deep: true })
</script>

<style scoped src="./styles.scss"></style>
