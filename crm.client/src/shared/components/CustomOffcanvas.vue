<template>
    <Teleport to="body">
        <div v-if="isVisible" class="offcanvas-backdrop fade show" @click="handleBackdropClick"></div>

        <div
            class="offcanvas offcanvas-end shadow"
            :class="[{ 'show': props.isVisible }, sizeClass]"
            :style="{ visibility: props.isVisible ? 'visible' : 'hidden' }"
            tabindex="-1"
        >
            <div class="offcanvas-header border-bottom">
                <h5 class="offcanvas-title fw-bold">{{ props.title }}</h5>
                <button
                    type="button"
                    class="btn-close"
                    @click="close"
                    v-if="props.closeOnBackdropClick"
                ></button>
            </div>

            <div class="offcanvas-body">
                <slot></slot>
            </div>
        </div>
    </Teleport>
</template>

<script lang="ts" setup>
import { computed } from 'vue'

interface Props {
    title: string
    isVisible: boolean
    closeOnBackdropClick?: boolean
    size?: 'sm' | 'md' | 'lg' | 'xl' | 'xxl'
}

const props = withDefaults(defineProps<Props>(), {
    title: 'Offcanvas Title',
    closeOnBackdropClick: true
})

const emit = defineEmits<{ (e: 'close'): void }>()

const close = () => emit('close')

const handleBackdropClick = () => {
    if (props.closeOnBackdropClick) close()
}

const sizeClass = computed(() => {
    return props.size ? `offcanvas-${props.size}` : ''
})
</script>


<style scoped>
.offcanvas {
    transition: transform 0.3s ease-in-out, visibility 0.3s ease-in-out;
}

:global(body.offcanvas-open) {
    overflow: hidden;
}
</style>
