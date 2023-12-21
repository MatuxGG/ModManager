import { createRouter, createWebHistory } from 'vue-router';
import ModsStore from './components/ModsStore.vue';
import ModsInstalled from './components/ModsInstalled.vue';
import AppSettings from './components/AppSettings.vue';
import AddLocal from './components/AddLocal.vue';
import CreditsPage from './components/CreditsPage.vue';
import LoadingPage from './components/LoadingPage.vue';
// import ServersList from './components/ServersList.vue';

const router = createRouter({
    history: createWebHistory(),
    routes: [
      { path: '/', component: LoadingPage },
      { path: '/library', component: ModsInstalled },
      { path: '/store', component: ModsStore },
      { path: '/settings', component: AppSettings },
      { path: '/addlocal', component: AddLocal },
      { path: '/credits', component: CreditsPage },
      // { path: '/servers', component: ServersList },
    ],
});
  
export default router;