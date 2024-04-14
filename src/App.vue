<template>
  <div id="themeDiv" class="dark">
    <div v-if="isNotLoadingPage" class="bg-white dark:bg-gray-800 text-black dark:text-white text-xs flex items-center justify-center h-full w-full min-h-screen">
      <MenuLeft :miniIcons="miniIcons" :menus="menus" />
      <div class="min-h-screen max-h-screen h-full flex grow p-2 overflow-auto">
        <div class="w-full">
          <router-view></router-view>
        </div>
      </div>
      <div id="popinDiv" class="z-10 fixed bottom-0 right-0 p-2 flex flex-col gap-2">
          
      </div>
    </div>
    <div v-else class="bg-white dark:bg-gray-800 text-black dark:text-white text-xs flex justify-center items-center justify-center h-full w-full min-h-screen">
      <router-view></router-view>
    </div>
  </div>
</template>

<script>
import MenuLeft from './components/MenuLeft.vue'
import './compiled.css';
import $ from 'jquery';

export default {
  name: 'App',
  components: {
    MenuLeft,
  },
  data() {
    return {
      menus: [
        { href: '/store', img: require('@/assets/download.png'), title: 'Mods Store'},
        { href: '/library', img: require('@/assets/mods.png'), title: 'Mods Library'},
        // { href: '/servers', img: require('@/assets/servers.png'), title: 'Servers'},
        { href: '/addlocal', img: require('@/assets/add.png'), title: 'Add Mod'},
        { href: '/settings', img: require('@/assets/settings.png'), title: 'Settings'},
        { href: '/credits', img: require('@/assets/credits.png'), title: 'Credits'},
      ],
      miniIcons: [
        { id: 'goodloss', src: require('@/assets/account.png'), href: 'https://goodloss.fr/login' },
        { id: 'discord', src: require('@/assets/discord.png'), href: 'https://goodloss.fr/discord' },
        { id: 'github', src: require('@/assets/github.png'), href: 'https://goodloss.fr/github' },
        { id: 'trello', src: require('@/assets/roadmap.png'), href: 'https://goodloss.fr/roadmap' },
      ],
    }
  },
  computed: {
    menusWithActiveState() {
      return this.menus.map(menu => ({
        ...menu,
        active: this.$route.path === menu.href
      }));
    },
    isNotLoadingPage() {
      return this.$route.path !== '/';
    }
  },
  watch: {
    '$route' () {
    }
  },
  methods: {
    updateAfterLoad() {
      const appData = this.$store.state.appData;
      document.getElementById("versionDiv").innerText = "Mod Manager Version " + appData.config.version;
      if (appData.config.theme === "dark") {
        document.getElementById("themeDiv").classList.remove("dark");
        document.getElementById("themeDiv").classList.add("dark");
      } else {
        document.getElementById("themeDiv").classList.remove("dark");
      }
    },
    openLink(url) {
      if (window.electronAPI && window.electronAPI.openExternal) {
        // Environnement Electron
        window.electronAPI.openExternal(url);
      } else {
        // Environnement web, ouvrir le lien dans un nouvel onglet
        window.open(url, '_blank').focus();
      }
    },
  },
  provide() {
    return {
      openLink: this.openLink,
    };
  },
  mounted() {
    this.$store.dispatch('loadAppData').then(() => {
      this.$router.push('/library').then(() => {
        // Attendre que Vue mette à jour le DOM après le changement de route
        this.$nextTick(() => {
          this.updateAfterLoad();
        });
      });
    });
    window.electronAPI.receiveData('showPopin', (text, id, classes) => {
      let popinId = "popin-"+id;
      let parentDiv = document.getElementById("popinDiv");
      let popinDiv = document.getElementById(popinId);
      if (!popinDiv) {
        popinDiv = document.createElement('div');
        popinDiv.id = popinId;
        popinDiv.classList.add('downloader-line', classes);
        // popinDiv.classList.add(classes);
        popinDiv.style.opacity = '0'
        parentDiv.appendChild(popinDiv);
        $(popinDiv).animate({ opacity: 1 }, 500);
      }

      popinDiv.innerHTML = text;
    });

    window.electronAPI.receiveData('hidePopin', (text, id, classes) => {
      let popinId = "popin-"+id;
      let parentDiv = document.getElementById("popinDiv");
      let popinDiv = document.getElementById(popinId);
      popinDiv.classList.remove(classes);
      popinDiv.classList.add('bg-green-700');
      popinDiv.innerHTML = text;
      // popinDiv.addEventListener('click', function () {
      //   parentDiv.removeChild(popinDiv);
      // })
      setTimeout(() => {
        if (popinDiv && parentDiv.contains(popinDiv)) {
          $(popinDiv).animate({ opacity: 0 }, 500);
          setTimeout(() => {
            if (parentDiv && popinDiv) {
              parentDiv.removeChild(popinDiv);
            }
          }, 500);
        }
      }, 5000);
    });

    window.electronAPI.receiveData('handleArgs', (action, args) => {
      switch (action) {
        case "startmod":
          window.electronAPI.sendData('startMod', args[0], args[1]);
          break;
        default:
          break;
      }
    });
  },
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>
