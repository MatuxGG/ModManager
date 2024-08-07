<template>
  <ConfirmPopin
      :visible="showStopModPopin"
      :message="`Are you sure you want to stop the mod?`"
      @confirm="confirmStopMod"
      @cancel="cancelStopMod"
  />
  <div class="h-full min-h-screen w-52 min-w-52 flex flex-col justify-between text-sm text-black dark:text-white bg-gray-400 dark:bg-gray-900 p-2">
      <div class="flex flex-col">
          <img class="w-full" src="../assets/modmanager_logo.png">
          <router-link v-for="menu in menus"
            :to="menu.href"
            :key="menu.title"
            class="cursor-pointer grid grid-cols-3 items-center gap-2 p-2"
            active-class="menu-left-shadow"
            exact>
              <img class="col-span-1 h-8 w-8" :src="menu.img" />
              <p class="col-span-2">{{ $t(menu.title) }}</p>
          </router-link>
      </div>

      <div class="text-xs flex flex-col items-center gap-2">
        <template v-if="$store.state.appData">
          <div v-if="startedMod !== false" @click.prevent="stopMod()" class="p-1 cursor-pointer flex flex-col justify-center items-center dark:bg-green-800 w-full rounded">
            <span v-if="startedMod[0].name === 'Vanilla'">{{ $t('Started vanilla') }}</span>
            <template v-if="startedMod[0] === 'Vanilla'">
              <span>{{ $t('Started vanilla') }}</span>
            </template>
            <template v-else>
              <span>{{ $t('Started mod') }}</span>
              <div class="flex flex-wrap gap-1">
                <span>{{ startedMod[0].name }}</span>
                <span>{{ startedMod[1].release.tag_name }}</span>
              </div>
            </template>
          </div>
          <div v-else @click.prevent="startVanilla()" class="flex justify-center cursor-pointer p-1 dark:bg-red-800 w-full rounded">
            <span>{{ $t('No mod started yet') }}</span>
          </div>
        </template>
          <div class="flex items-center justify-between gap-2">
             <a v-for="miniIcon in miniIcons" :key="miniIcon.id" @click.prevent="openLink(miniIcon.href)">
                <img class="image-icon cursor-pointer" :src="miniIcon.src" />
              </a>
            </div>
          <p class="text-center text-sm" id="versionDiv"></p>
      </div>
  </div>
</template>
  
<script>
  import ConfirmPopin from "./ConfirmPopin.vue";

  export default {
    components: {ConfirmPopin},
    data() {
      return {
        showStopModPopin: false
      };
    },
    props: {
      miniIcons: Array,
      menus: Array
    },
    inject: [
        'openLink'
    ],
    computed: {
      startedMod() {
        return this.$store.getters.startedMod();
      },
    },
    methods: {
      stopMod() {
        this.showStopModPopin = true;
      },
      confirmStopMod() {
        this.showStopModPopin = false;
        window.electronAPI.sendData('stopCurrentMod');
      },
      cancelStopMod() {
        this.showStopModPopin = false;
      },
      startVanilla() {
        window.electronAPI.sendData('startVanilla');
      },
    }
  }
</script>
  

  