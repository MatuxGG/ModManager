import { createApp } from 'vue'
import App from './App.vue'
import router from './router';
import store from './store';
import { createI18n } from 'vue-i18n';

import enMessages from './translations/en.js';
import frMessages from './translations/fr.js';

const i18n = createI18n({
    legacy: false,
    locale: 'fr',
    fallbackLocale: 'en',
    messages: {
        'en': enMessages,
        'fr': frMessages,
    },
});

createApp(App)
    .use(router)
    .use(store)
    .use(i18n)
    .mount('#app')