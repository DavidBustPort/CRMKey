import { createApp } from 'vue'
import App from './App.vue'

import router from './app/router'

import './core/styles/main.scss'
import 'bootstrap/dist/js/bootstrap.min.js'
import icons from './config/fontAwesome'

import { VueDatePicker } from '@vuepic/vue-datepicker'
import '@vuepic/vue-datepicker/dist/main.css'

import { createPinia } from 'pinia'
import piniaPlugin from 'pinia-plugin-persistedstate'
const pinia = createPinia().use(piniaPlugin)

import PrimeVue from 'primevue/config'
import Aura from '@primevue/themes/aura'

import 'animate.css'

import 'notivue/notification.css'
import 'notivue/animations.css'
import { createNotivue } from 'notivue'
const notivue = createNotivue({
    position: 'top-right',
    limit: 3,
    enqueue: true,
    pauseOnHover: true
})

import { setupInterceptors } from './core/interceptors'

const app = createApp(App)

app.use(pinia)
app.use(router)
app.use(PrimeVue, {
    theme: {
        preset: Aura
    }
})
app.use(notivue)

setupInterceptors()

app.component('font-awesome-icon', icons)
app.component('VueDatePicker', VueDatePicker)

app.mount('#app')
