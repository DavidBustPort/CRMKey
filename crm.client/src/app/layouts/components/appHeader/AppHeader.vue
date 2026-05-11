<template>
    <nav class="navbar navbar-expand navbar-bg">
        <a href="#" role="button" class="sidebar-toggle" @click.prevent="appStore.toggleSidebar">
            <i class="hamburger align-self-center"></i>
        </a>
        <div class="d-flex align-items-center">
            <span class="me-2 fw-bold">CRM</span>
            <span class="text-primary px-3">
                ¿¿??
            </span>
        </div>
        <div class="navbar-collapse collapse">
            <AppHeaderMenu />
        </div>
    </nav>
</template>


<script lang="ts" setup>
import { useAppStore } from '@/core/store/appStore'
import AppHeaderMenu from './AppHeaderMenu.vue'

const appStore = useAppStore()
</script>
