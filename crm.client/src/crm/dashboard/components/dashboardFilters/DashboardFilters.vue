<template>
    <div class="dashboard-header mb-4">
        <div class="card border-0 shadow-sm pt-1">
            <div class="card-body">
                <div class="row align-items-center">
                    <div class="col-12 col-lg-7">
                        <div class="d-flex align-items-center">
                            <div class="icon-box me-3">
                                <FontAwesomeIcon :icon="['fas', 'tachometer-alt']" class="text-primary fs-4" />
                            </div>
                            <div>
                                <h4 class="text-dark fw-bold mb-1">Dashboard CRM</h4>
                                <div class="user-info-bar d-flex align-items-center gap-3">
                                    <span class="info-item">
                                        <FontAwesomeIcon :icon="['fas', 'user']" class="text-primary opacity-75" />
                                        <span class="ms-1">{{ sessionStore.userName }}</span>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { useSessionStore } from '@/core/store/sessionStore'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

const sessionStore = useSessionStore()
</script>

<style scoped src="./styles.scss"></style>
