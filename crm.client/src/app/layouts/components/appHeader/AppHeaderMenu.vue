<template>
    <ul class="navbar-nav navbar-align custom-nav">
        <li v-if="isProduction" class="nav-item">
            <a type="button" class="btn btn-link text-decoration-underline" href="../inicio.aspx">
                <FontAwesomeIcon :icon="['fas','home']" />
                Volver a SIANWEB
            </a>
        </li>

        <AppHeaderMenuFilterByRik v-if="showFilterByRik" />

        <li class="dropdown nav-item">
            <a href="" role="button" class="nav-link dropdown-toggle d-none d-sm-inline-block" data-bs-toggle="dropdown" aria-expanded="false">
                <span class="text-dark">{{ sessionStore?.userName }}</span>
            </a>
            <div class="dropdown-menu dropdown-menu-end">
                <a href="#" class="dropdown-item">Configuración</a>
                <a href="#" class="dropdown-item">...</a>
                <div class="dropdown-divider"></div>
                <a href="#" class="dropdown-item" role="button" @click="authStore.logout">
                    <FontAwesomeIcon :icon="['fas', 'right-from-bracket']" />
                    Salir del CRM
                </a>
            </div>
        </li>
        <li class="nav-item" v-if="currentRoute.meta?.fullWidth">
            <button
                type="button"
                class="btn btn-outline-secondary ms-2"
                :title="titleLayoutMode"
                @click="appStore.toggleLayoutMode"
            >
                <FontAwesomeIcon :icon="['fas', 'up-right-and-down-left-from-center']" />
            </button>
        </li>
    </ul>
</template>

<script lang="ts" setup>
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { useSessionStore } from '@/core/store/sessionStore'
import { computed } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { useAppStore } from '@/core/store/appStore'
import AppHeaderMenuFilterByRik from './AppHeaderMenuFilterByRik.vue'
import { useAuthStore } from '@/core/store/authStore'

const router = useRouter()
const route = useRoute()
const sessionStore = useSessionStore()
const authStore = useAuthStore()
const appStore = useAppStore()

const isProduction = import.meta.env.PROD

const currentRoute = computed(() => router.currentRoute.value)
const titleLayoutMode = computed(() =>
    appStore.layoutMode === 'container'
    ? 'Cambiar a diseño de pantalla completa'
    : 'Cambiar a diseño centrado'
)

const showFilterByRik = computed(() => {
    return route.meta?.allowRikFiltering && sessionStore.isUserManager && appStore.mode === 'sianweb'
})
</script>

<style scoped>
.custom-nav .nav-item:not(:last-child)::after {
    content: "|";
    color: #6c757d;
    margin: 0 15px;
    font-weight: 300;
}
</style>
