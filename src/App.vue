<template>
  <div class="bg-gray-500 text-white text-sm flex items-center justify-center h-full w-full min-h-screen">
    <MenuLeft :version="version" :miniIcons="miniIcons" :menus="menus" />
    <div class="min-h-screen h-full flex grow p-2">
      
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
        { img: require('@/assets/mods.png'), title: 'Mods', active: true},
        { img: require('@/assets/servers.png'), title: 'Servers', active: false},
        { img: require('@/assets/add.png'), title: 'Add Local', active: false},
        { img: require('@/assets/settings.png'), title: 'Settings', active: false},
        { img: require('@/assets/credits.png'), title: 'Credits', active: false},
      ],
      miniIcons: [
        { id: 'goodloss', src: require('@/assets/account.png') },
        { id: 'discord', src: require('@/assets/discord.png') },
        { id: 'github', src: require('@/assets/github.png') },
        { id: 'trello', src: require('@/assets/roadmap.png') },
      ],
    }
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
