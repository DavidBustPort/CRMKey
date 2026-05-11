import { onMounted, onUnmounted, ref, type Ref } from 'vue'

interface ScrollToTop {
    show: Ref<boolean>
    scrollToTop: () => void
}

export function useScrollToTop(): ScrollToTop {
    const show = ref<boolean>(false)

    const scrollToTop = (): void => {
        window.scrollTo({
            top: 0,
            behavior: 'smooth'
        })
    }

    const handleScroll = (): void => {
        show.value = window.scrollY > 250
    }

    onMounted(() => window.addEventListener('scroll', handleScroll))
    onUnmounted(() => window.removeEventListener('scroll', handleScroll))

    return {
        show,
        scrollToTop
    }
}
