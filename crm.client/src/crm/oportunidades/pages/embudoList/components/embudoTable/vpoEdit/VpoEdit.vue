<template>
    <div class="vpo-editable-container">
        <div v-if="!isEditing" class="d-flex align-items-center justify-content-between">
            <span class="vpo-amount me-2">{{ formatCurrency(props.vpo) }}</span>
            <button
                @click="startEdit"
                class="btn btn-sm btn-outline-primary vpo-edit-btn"
                :title="'Editar VPO'"
                :disabled="loading"
                type="button"
            >
                <FontAwesomeIcon :icon="['fas', 'edit']" />
            </button>
        </div>

        <div v-else>
            <div class="d-flex align-items-center justify-content-end">
                <div class="position-relative">
                    <input
                        type="number"
                        v-model.number="vpoEdit"
                        @keyup.enter="save"
                        @keyup.escape="cancel"
                        min="0"
                        :disabled="loading"
                        style="width: 110px"
                        ref="inputRef"
                        :class="['form-control form-control-sm me-1', { 'is-invalid': isInvalid }]"
                    >
                </div>

                <button
                    class="btn btn-sm btn-success me-1"
                    title="Guardar"
                    @click="save"
                    :disabled="isInvalid || loading"
                >
                    <FontAwesomeIcon v-if="!loading" :icon="['fas', 'check']" />
                    <span v-else class="spinner-border spinner-border-sm"></span>
                </button>

                <button
                    class="btn btn-sm btn-secondary"
                    :disabled="loading"
                    title="Cancelar"
                    @click="cancel"
                >
                    <FontAwesomeIcon :icon="['fas', 'times']" />
                </button>
            </div>

            <div v-if="isInvalid" class="invalid-feedback d-block text-end">
                Valor requerido (min. 0)
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
import { formatCurrency } from '@/core/utils/numbers'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { computed, nextTick, ref } from 'vue'
import { EmbudoListService } from '../../../services/embudoList-service'
import { useEmbudoListStore } from '../../../store/embudoListStore'
import { push } from 'notivue'

const props = defineProps<{
    oportunidadId: number
    vpo: number
}>()

const store = useEmbudoListStore()
const vpoEdit = ref<number | null>(props.vpo)
const inputRef = ref<HTMLInputElement | null>(null)
const isEditing = ref<boolean>(false)
const loading = ref<boolean>(false)

const isInvalid = computed(() => vpoEdit.value === null || vpoEdit.value < 0)

const startEdit = async () => {
    isEditing.value = true
    await nextTick()
    inputRef.value?.focus()
}

const cancel = (): void => {
    isEditing.value = false
    vpoEdit.value = props.vpo
}

const save = async (): Promise<void> => {
    if (isInvalid.value || loading.value) return

    loading.value = true
    try {
        const res = await EmbudoListService.actualizarVpo({
            oportunidadId: props.oportunidadId,
            vpo: vpoEdit.value as number
        })

        if (res.succeeded && res.data) {
            push.success({
                title: '¡Éxito!',
                message: 'VPO actualizado correctamente'
            })
            const oportunidad = store.oportunidades.oportunidades.find(o => o.oportunidadId === props.oportunidadId)
            if (oportunidad) {
                oportunidad.vpo = vpoEdit.value as number
            }
            isEditing.value = false
        } else handleError(res.message || 'No se puedo actualizar el valor')
    } catch {
        handleError('Error de conexión')
    }
    finally { loading.value = false }
}

const handleError = (message: string) => {
    push.error({
        title: 'Error de actualización',
        message
    })
    inputRef.value?.focus()
}
</script>

<style scoped lang="scss" src="./styles.scss"></style>
