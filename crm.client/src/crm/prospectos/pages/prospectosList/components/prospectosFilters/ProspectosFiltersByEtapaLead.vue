<template>
    <div class="mb-2" :class="{ 'filter-disabled': store.isLoading }">
        <label for="etapaLeads" class="form-label fst-italic">
            Etapa Leads
        </label>
        <select
            v-model.number="store.filters.byEtapaLead"
            :disabled="store.isLoading"
            class="form-select p-2"
            id="etapaLeads"
        >
            <option :value="null">Todos</option>
            <option :value="EtapaLead.CDI_GTE">CDI -> GTE</option>
            <option :value="EtapaLead.CDI_RIK">CDI -> RIK</option>
        </select>
    </div>
</template>

<script lang="ts" setup>
import { useProspectosListStore } from '../../store/prospectosListStore'
import { EtapaLead } from '../../store/types'

const store = useProspectosListStore()
</script>
