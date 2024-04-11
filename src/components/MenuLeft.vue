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
        <div class="flex flex-col items-center gap-4">
            <div class="flex items-center justify-between gap-4">
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
  }
</script>
  

  