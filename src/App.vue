<template>
  <div class="bg-gray-500 text-white text-sm flex items-center justify-center h-full w-full min-h-screen">
    <MenuLeft :version="version" :miniIcons="miniIcons" :menus="menus" />
    <div class="min-h-screen max-h-screen h-full flex grow p-2 overflow-auto">
      <div class="w-full">
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>

<script>
import MenuLeft from './components/MenuLeft.vue'
import './compiled.css';

export default {
  name: 'App',
  components: {
    MenuLeft,
  },
  data() {
    return {
      version: 'Mod Manager Version 7 Beta',
      menus: [
        { href: '/store', img: require('@/assets/download.png'), title: 'Mods Store'},
        { href: '/', img: require('@/assets/mods.png'), title: 'Library'},
        { href: '/servers', img: require('@/assets/servers.png'), title: 'Servers'},
        { href: '/addlocal', img: require('@/assets/add.png'), title: 'Add Local'},
        { href: '/settings', img: require('@/assets/settings.png'), title: 'Settings'},
        { href: '/credits', img: require('@/assets/credits.png'), title: 'Credits'},
      ],
      miniIcons: [
        { id: 'goodloss', src: require('@/assets/account.png'), href: 'https://goodloss.fr/login' },
        { id: 'discord', src: require('@/assets/discord.png'), href: 'https://goodloss.fr/discord' },
        { id: 'github', src: require('@/assets/github.png'), href: 'https://goodloss.fr/github' },
        { id: 'trello', src: require('@/assets/roadmap.png'), href: 'https://goodloss.fr/roadmap' },
      ]
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
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}
</style>
