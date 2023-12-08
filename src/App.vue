<template>
  <div id="themeDiv" class="dark">
    <div class="bg-white dark:bg-gray-800 text-black dark:text-white text-sm flex items-center justify-center h-full w-full min-h-screen">
      <MenuLeft :version="version" :miniIcons="miniIcons" :menus="menus" />
      <div class="min-h-screen max-h-screen h-full flex grow p-2 overflow-auto">
        <div class="w-full">
          <router-view></router-view>
        </div>
      </div>
      <div id="popinDiv" class="z-10 fixed bottom-0 right-0 p-2 flex flex-col gap-2">
          
      </div>
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
        { href: '/', img: require('@/assets/mods.png'), title: 'Mods Library'},
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
    }
  },
  watch: {
    '$route' () {
    }
  },
  mounted() {
    this.$store.dispatch('loadAppData');
    window.electronAPI.receiveData('showPopin', (text, id) => {
      let popinId = "popin-"+id;
      let parentDiv = document.getElementById("popinDiv");
      let popinDiv = document.getElementById(popinId);
      if (!popinDiv) {
        popinDiv = document.createElement('div');
        popinDiv.id = popinId;
        popinDiv.classList.add('downloader-line');
        popinDiv.style.opacity = '0'
        parentDiv.appendChild(popinDiv);
        $(popinDiv).animate({ opacity: 1 }, 500);
      }

      popinDiv.innerHTML = text;
    });

    window.electronAPI.receiveData('hidePopin', (id) => {
      let popinId = "popin-"+id;
      let parentDiv = document.getElementById("popinDiv");
      let popinDiv = document.getElementById(popinId);
      setTimeout(() => {
        if (popinDiv && parentDiv.contains(popinDiv)) {
          $(popinDiv).animate({ opacity: 0 }, 500);
          setTimeout(() => {
            parentDiv.removeChild(popinDiv);
          }, 500);
        }
      }, 5000);
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
