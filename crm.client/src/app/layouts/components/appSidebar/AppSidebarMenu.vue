<template>
    <ul class="sidebar-nav">
        <li class="sidebar-header">Páginas</li>
        <template v-for="route in routes" :key="route.path">
            <li
                class="sidebar-item"
                :class="{ 'active': route.path === currentRoute, 'has-submenu': hasChildren(route) }"
            >
                <div
                    v-if="hasChildren(route)"
                    @click="toggleSubmenu(route.path)"
                    class="d-flex align-items-center sidebar-link"
                >
                    <FontAwesomeIcon :icon="route.meta?.icon ?? 'fa-circle-user'" />
                    <span class="ms-2">{{ route.name }}</span>
                    <FontAwesomeIcon class="ms-auto" :icon="isOpenSubmenu[route.path] ? 'fa-chevron-down' : 'fa-chevron-up'" />
                </div>

                <RouterLink
                    v-else
                    :to="route.path"
                    class="sidebar-link"
                >
                    <FontAwesomeIcon :icon="route.meta.icon ?? 'fa-circle-user'" /> {{ route.name }}
                </RouterLink>

                <AppSidebarMenuSubmenu
                    :children="route.children"
                    v-if="hasChildren(route) && isOpenSubmenu[route.path]" />
            </li>
        </template>
    </ul>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { computed, reactive, watch } from 'vue'
import { useRoute, useRouter, type RouteRecordNormalized } from 'vue-router'
import AppSidebarMenuSubmenu from './AppSidebarMenuSubmenu.vue'

const router = useRouter()
const route = useRoute()

const isOpenSubmenu = reactive<Record<string, boolean>>({})

const hasChildren = (route: RouteRecordNormalized): boolean => route.children?.some(c => c.meta?.showInSidebar)
const toggleSubmenu = (path: string) => isOpenSubmenu[path] = !isOpenSubmenu[path]

const routes = computed(() => {
    return router.getRoutes().filter(route =>
        route.meta?.showInSidebar &&
        route.meta?.isSidebarGroup
    )
})
const currentRoute = computed(() => router.currentRoute.value.path)

watch(() => route.path, () => {
    routes.value.forEach(r => {
        if (r.children?.some(c => c.name === route.name)) {
            isOpenSubmenu[r.path] = true
        }
    })
}, { immediate: true })
</script>

<style scoped>
.has-submenu {
    .sidebar-link {
        user-select: none;
    }
}
</style>
