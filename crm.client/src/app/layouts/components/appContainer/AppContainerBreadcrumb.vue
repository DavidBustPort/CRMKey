<template>
    <div
        v-if="breadcrumbs.length > 1"
        class="d-flex align-items-center justify-content-center justify-content-md-start px-0 py-3 border-bottom"
    >
        <button class="btn btn-link btn-sm text-decoration-none me-2 p-0">
            <FontAwesomeIcon :icon="['fas', 'chevron-left']" class="text-primary" />
        </button>
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb mb-0">
                <li
                    v-for="(b, index) in breadcrumbs"
                    :key="index"
                    class="breadcrumb-item"
                    :class="{ 'active': index === breadcrumbs.length - 1}"
                >
                    <RouterLink
                        :to="b.path"
                        class="text-decoration-none"
                        v-if="index < breadcrumbs.length -1 && b.path"
                    >
                        <FontAwesomeIcon v-if="b.icon" :icon="b.icon" class="me-1" /> {{ b.name }}
                    </RouterLink>
                    <span v-else class="text-muted">
                        <FontAwesomeIcon v-if="b.icon" :icon="b.icon" class="me-1" /> {{ b.name }}
                    </span>
                </li>
            </ol>
        </nav>
    </div>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { computed } from 'vue'
import { useRoute } from 'vue-router'

interface BreadcrumbItem {
    name: string
    path: string
    icon?: string
}

const route = useRoute()

const breadcrumbs = computed<BreadcrumbItem[]>(() => {
    const matched = route.matched.filter(record => record.name)
    const crumbs: BreadcrumbItem[] = []

    crumbs.push({
        name: 'Inicio',
        path: '/',
        icon: 'fa-house'
    })

    for (let i = 0; i < matched.length; i++) {
        const record = matched[i]
        const isLast = i === matched.length - 1
        const meta = record?.meta || {}
        const displayName: string = meta.breadcrumbName || record?.name as string

        // Solo agregar si no es redundante con el breadcrumb anterior
        const lastCrumb = crumbs[crumbs.length - 1]
        if (!lastCrumb || lastCrumb.name !== displayName) {
            crumbs.push({
                name: displayName,
                path: isLast ? '' : record?.path ?? '',
                icon: meta?.icon
            })
        }
    }

    return crumbs
})
</script>
