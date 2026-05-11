<template>
    <ul class="sidebar-subnav">
        <li
            v-for="route in props.children"
            class="sidebar-item"
            :key="route.path"
            :class="{ 'active': isChildActive(route) }"
        >
            <RouterLink
                :to="{ name: route.name }"
                class="sidebar-link"
            >
                <FontAwesomeIcon :icon="route.meta?.icon ?? 'fa-circle-user'" />
                {{ route.name }}
            </RouterLink>
        </li>
    </ul>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { useRoute, type RouteRecordRaw } from 'vue-router'

const props = defineProps<{ children: RouteRecordRaw[] }>()

const route = useRoute()

const isChildActive = (child: RouteRecordRaw): boolean => route.name === child.name
</script>

<style scoped>
.sidebar-subnav {
    padding-left: 1.5rem;
    list-style: none;
}
</style>
