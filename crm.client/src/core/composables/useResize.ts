import { onBeforeUnmount, onMounted, ref, type Ref } from 'vue'

interface Resize {
    isMobile: Ref<boolean>
}

export function useResize(): Resize {
    const isMobile = ref<boolean>(false)

    const updateResize = (): void => {
        if (!window) return
        isMobile.value = window.innerWidth < 1025
    }

    onMounted(() => {
        updateResize()
        window.addEventListener('resize', updateResize)
    })

    onBeforeUnmount(() => window.removeEventListener('resize', updateResize))

    return { isMobile }
}
