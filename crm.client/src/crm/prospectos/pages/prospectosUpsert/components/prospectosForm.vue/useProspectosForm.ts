import { ref, type Ref } from 'vue'

interface ProspectosForm {
    submitted: Ref<boolean>
    handleSubmit: () => Promise<void>
}
export function useProspectosForm(): ProspectosForm {
    const submitted = ref<boolean>(false)

    async function handleSubmit(): Promise<void> {
        submitted.value = true
    }

    return {
        submitted,
        handleSubmit
    }
}
