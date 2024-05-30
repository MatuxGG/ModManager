import { createApp } from 'vue'
import App from './App.vue'
import router from './router';
import store from './store';
import { createI18n } from 'vue-i18n';
import axios from 'axios';

const i18n = createI18n({
    legacy: false,
    locale: 'fr',
    fallbackLocale: 'en',
    messages: {},
});

const loadLocaleMessages = async (locale) => {
    try {
        const response = await axios.get(`https://goodloss.fr/api/trans/${locale}`);
        const messages = response.data.reduce((acc, item) => {
            acc[item.original] = item.translation;
            return acc;
        }, {});
        i18n.global.setLocaleMessage(locale, messages);
    } catch (error) {
        console.error(`Failed to load translations for locale ${locale}:`, error);
    }
};

const loadAllTranslations = async () => {
    try {
        const response = await axios.get('https://goodloss.fr/api/trans');
        const languages = response.data;

        const loadTranslationsPromises = languages.map(lang => loadLocaleMessages(lang.code.toLowerCase()));

        await Promise.all(loadTranslationsPromises);
        return languages;
    } catch (error) {
        console.error('Failed to load all translations:', error);
        return [];
    }
};

const setupApp = async () => {
    const languages = await loadAllTranslations();

    const app = createApp(App);
    app.config.globalProperties.$languages = languages;

    app.use(router)
        .use(store)
        .use(i18n)
        .mount('#app');
};

setupApp();