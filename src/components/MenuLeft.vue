<template>
    <div class="h-full min-h-screen w-64 flex flex-col justify-between text-lg bg-gray-800 p-2">
        <div class="flex flex-col">
            <img class="w-full" src="../assets/modmanager_logo.png">
            <div v-for="menu in menus" :key="menu.title" class="cursor-pointer flex items-center gap-4 py-2 border-orange-400" :class="{ 'border-l pl-1': menu.active }">
                <img class="h-12 w-12" :src="menu.img" />
                <p :class="{ 'font-bold': menu.active }">{{ menu.title }}</p>
            </div>
        </div>
        <div class="flex flex-col items-center gap-4">
            <div class="flex items-center justify-between gap-4">
                <img v-for="miniIcon in miniIcons" :key="miniIcon.id" class="h-6 w-6 cursor-pointer" :src="miniIcon.src" />
            </div>
            <p>{{ version }}</p>
        </div>
    </div>
</template>
  
<script>
  export default {
    props: {
      version: String,
      miniIcons: Array,
      menus: Array
    },
  }
</script>
  

  