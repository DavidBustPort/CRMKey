import { onMounted, ref, watch, type Ref } from 'vue'
import type { Pagination } from './types'

interface Pag {
    setCurrentPage(page: number): boolean
    arrayItemsPerPage: number[]
    totalPages: Ref<number>
    pageList: Ref<number[]>
    itemsPerPage: Ref<number>
    showItemsPerPageOptions?: Ref<boolean>
}

export function usePagination(config: Pagination): Pag {
    const arrayItemsPerPage: number[] = config.arrayItemsPerPage ?? [5, 10, 15]
    const totalPages = ref<number>(0)
    const maxPages = config.maxPages ?? 5
    const pageList = ref<number[]>([])
    const itemsPerPage = ref<number>(config.itemsPerPage)
    const showItemsPerPageOptions = ref<boolean>(config.showItemsPerPageOptions ?? true)

    const setPagination = (currentPage: number) => {
        totalPages.value = Math.ceil(config.totalRows / config.itemsPerPage)
        let initialPage = 1
        let lastPage = totalPages.value

        if (totalPages.value > maxPages) {
            if (currentPage === totalPages.value) initialPage += currentPage - maxPages
            else {
                initialPage += currentPage >= maxPages
                ? ((currentPage - maxPages) + 1)
                : 0
            }

            lastPage = currentPage >= maxPages
            ? ((maxPages + initialPage) - 1)
            : maxPages
        }

        let i = initialPage
        pageList.value = Array(lastPage - initialPage + 1)
        .fill(0)
        .map(() => i++)
    }

    const setCurrentPage = (page: number): boolean => {
        if (page === 0 && pageList.value[0] === 1) return false
        if (page > totalPages.value) return false

        setPagination(page)
        return true
    }

    watch(
        () => [config.currentPage, config.totalRows, config.itemsPerPage],
        () => setPagination(config.currentPage),
        { immediate: true }
    )

    onMounted(() => setPagination(config.currentPage))

    return {
        setCurrentPage,
        arrayItemsPerPage,
        totalPages,
        pageList,
        itemsPerPage,
        showItemsPerPageOptions
    }
}
