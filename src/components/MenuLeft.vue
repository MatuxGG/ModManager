<template>
    <div class="h-full min-h-screen w-52 min-w-52 flex flex-col justify-between text-sm text-white bg-gray-500 dark:bg-gray-900 p-2">
        <div class="flex flex-col">
            <img class="w-full" src="../assets/modmanager_logo.png">
            <router-link v-for="menu in menus"
              :to="menu.href"
              :key="menu.title"
              class="cursor-pointer grid grid-cols-3 items-center gap-2 p-2"
              active-class="menu-left-shadow font-bold"
              exact>
                <img class="col-span-1 h-8 w-8" :src="menu.img" />
                <p class="col-span-2">{{ menu.title }}</p>
            </router-link>
        </div>

        <div class="text-xs flex flex-col items-center gap-2">
          <template v-if="$store.state.appData">
            <div v-if="startedMod !== false" class="p-1 flex flex-col justify-center items-center dark:bg-green-800 w-full rounded">
              <span>Started mod</span>
              <div class="flex flex-wrap gap-1">
                <span>{{ startedMod[0].name }}</span>
                <span>{{ startedMod[1].version }}</span>
              </div>
            </div>
            <div v-else class="flex justify-center p-2 dark:bg-red-800 w-full rounded">
              <span>No mod started yet</span>
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

  export default {
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
  }
</script>
  

  