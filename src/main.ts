import { createApp } from 'vue'
import App from './App.vue'
import router from './import/router';
import {store} from './import/store';
import { createI18n } from 'vue-i18n';
import axios from 'axios';

import './compiled.css'

let translations: any = [];

const i18n = createI18n({
    legacy: false,
    locale: 'en',
    fallbackLocale: 'en',
    messages: {},
});

const loadLocaleMessages = async (locale: string) => {
    const retryInterval = 1000; // 1 seconde
    const maxRetryTime = 10000; // 10 secondes
    let startTime = Date.now();

    const fetchTranslations: any = async () => {
        try {
            const response = await axios.get(`https://goodloss.fr/api/trans/${locale}`);
            const messages = response.data.reduce((acc: any, item: any) => {
                acc[item.original] = item.translation;
                return acc;
            }, {});
            i18n.global.setLocaleMessage(locale, messages);
            translations[locale] = messages;
            console.log(`Translations loaded successfully for locale ${locale}`);
            return true;
        } catch (error) {
            const elapsedTime = Date.now() - startTime;
            if (elapsedTime < maxRetryTime) {
                console.warn(`Failed to load translations for locale ${locale}, retrying...`);
                await new Promise(res => setTimeout(res, retryInterval));
                return fetchTranslations();
            } else {
                console.error(`Failed to load translations for locale ${locale} after multiple attempts:`, error);
                return false;
            }
        }
    };

    return fetchTranslations();
};

const loadAllTranslations = async () => {
    const retryInterval = 1000; // 1 seconde
    const maxRetryTime = 10000; // 10 secondes
    let startTime = Date.now();

    const fetchTranslations: any = async () => {
        try {
            const response = await axios.get('https://goodloss.fr/api/trans');
            const languages = response.data;

            const loadTranslationsPromises = languages.map((lang: any) => loadLocaleMessages(lang.code.toLowerCase()));

            await Promise.all(loadTranslationsPromises);
            console.log('All translations loaded successfully');
            return languages;
        } catch (error) {
            const elapsedTime = Date.now() - startTime;
            if (elapsedTime < maxRetryTime) {
                console.warn('Failed to load all translations, retrying...');
                await new Promise(res => setTimeout(res, retryInterval));
                return fetchTranslations();
            } else {
                console.error('Failed to load all translations after multiple attempts:', error);
                return [];
            }
        }
    };

    return fetchTranslations();
};

const setupApp = async () => {
    const languages = await loadAllTranslations();

    const app = createApp(App);
    app.config.globalProperties.$languages = languages;
    app.config.globalProperties.$translations = translations;

    app.use(router)
        .use(store)
        .use(i18n)
        .mount('#app');
};

setupApp();