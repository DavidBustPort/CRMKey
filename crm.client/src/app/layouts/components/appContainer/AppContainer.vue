<template>
    <div :class="appStore.layoutMode">
        <div class="row">
            <div :class="route.meta.mainContainerColumn ?? 'col-12'">
                <div class="row mb-3">
                    <AppContainerBreadcrumb />
                </div>
                <RouterView />
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { useAppStore } from '@/core/store/appStore'
import { useRoute } from 'vue-router'
import AppContainerBreadcrumb from './AppContainerBreadcrumb.vue'

const appStore = useAppStore()
const route = useRoute()
</script>
