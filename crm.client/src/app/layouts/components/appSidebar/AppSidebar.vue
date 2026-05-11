<template>
    <nav class="sidebar" :class="{ 'collapsed': !appStore.sidebarOpen }">
        <div class="sidebar-content">
            <a class="sidebar-brand text-center" href="#">
                <img src="/src/assets/logo.png" alt="logo">
            </a>
            <AppSidebarMenu />
        </div>
    </nav>
</template>

<script lang="ts" setup>
import { useAppStore } from '@/core/store/appStore'
import AppSidebarMenu from './AppSidebarMenu.vue'

const appStore = useAppStore()
</script>
