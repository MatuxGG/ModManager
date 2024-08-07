import {createRouter, createWebHistory, Router} from 'vue-router';
import ModsStore from '../components/ModsStore.vue';
import ModsInstalled from '../components/ModsInstalled.vue';
import AppSettings from '../components/AppSettings.vue';
import AddLocal from '../components/AddLocal.vue';
import CreditsPage from '../components/CreditsPage.vue';
import LoadingPage from '../components/LoadingPage.vue';
import UpdatingPage from '../components/UpdatingPage.vue';
// import ServersList from './components/ServersList.vue';

const router: Router = createRouter({
    history: createWebHistory(),
    routes: [
      { path: '/', component: LoadingPage },
      { path: '/updating', component: UpdatingPage },
      { path: '/library', component: ModsInstalled },
      { path: '/store', component: ModsStore },
      { path: '/settings', component: AppSettings },
      { path: '/addlocal', component: AddLocal },
      { path: '/credits', component: CreditsPage },
      // { path: '/servers', component: ServersList },
    ],
});
  
export default router;