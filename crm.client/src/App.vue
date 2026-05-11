<template>
	<PageLoadingView v-if="appStore.isPageLoading" />
    <AppLayout v-else-if="isFullyAuthenticated" />
    <RouterView v-else />
</template>

<script lang="ts" setup>
import PageLoadingView from './app/views/PageLoadingView.vue'
import { useAppStore } from './core/store/appStore'
import AppLayout from './app/layouts/AppLayout.vue'
import { useApp } from './core/composables/useApp'
import { onMounted } from 'vue'
import { useAuthStore } from './core/store/authStore'

const appStore = useAppStore()
const authStore = useAuthStore()
const { isFullyAuthenticated } = useApp()

onMounted(() => {
    if (import.meta.env.DEV) {
		authStore.logout()
	}
})
</script>
