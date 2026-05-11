<template>
    <tr
        v-for="i in 3"
        :key="i"
        class="loading-row"
        v-bind="$attrs"
    >
        <td :colspan="props.colspan" class="py-3 px-4">
            <div class="skeleton-wrapper">
                <div class="skeleton-bone skeleton-shimmer circle"></div>
                <div class="skeleton-bone skeleton-shimmer text-line w-75"></div>
                <div class="skeleton-bone skeleton-shimmer text-line w-25 ms-auto"></div>
            </div>
        </td>
    </tr>
</template>

<script lang="ts" setup>
const props = defineProps<{ colspan: number }>()
</script>

<style scoped>
.loading-row {
    border-bottom: 1px solid #f0f0f0;
}
.skeleton-wrapper {
    display: flex;
    align-items: center;
    gap: 1rem;
}
.skeleton-bone {
    background: #ececf1;
    border-radius: 4px;
    height: 1rem;
}
.circle {
    width: 24px;
    height: 24px;
    border-radius: 50%;
    flex-shrink: 0;
}
.text-line {
    height: 12px;
}
.skeleton-shimmer {
    position: relative;
    overflow: hidden;
    background-color: #e2e5e7;
}
.skeleton-shimmer::after {
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    transform: translateX(-100%);
    background-image: linear-gradient(
        90deg,
        rgba(255, 255, 255, 0) 0,
        rgba(255, 255, 255, 0.2) 20%,
        rgba(255, 255, 255, 0.5) 60%,
        rgba(255, 255, 255, 0)
    );
    animation: shimmer 2s infinite;
    content: '';
}
@keyframes shimmer {
    100% {
        transform: translateX(100%);
    }
}
</style>
