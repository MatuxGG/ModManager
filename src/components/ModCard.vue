<template>
  <div class="border rounded flex flex-col justify-between gap-4 p-4 bg-gray-300 dark:bg-gray-700 min-w-[300px]" >
    <!-- Div haut -->
    <div class="flex flex-col gap-1">
      <!-- Ligne titre + flag -->
      <div class="flex items-center gap-4 justify-between">
        <!-- Name -->
        <a v-if="mod.author && mod.githubLink"
           @click.prevent="openLink(`https://github.com/${mod.author}/${mod.github}`)"
           class="cursor-pointer uppercase text-sm text-blue-500">
          {{ mod.name }}
        </a>
        <p v-else class="uppercase text-sm text-blue-500">
          {{ mod.name }}
        </p>

        <!-- Country flag -->
        <template v-if="mod.countries === 'fr'">
          <img class="h-5 border border-black dark:border-white" src="../assets/fr.png" />
        </template>
        <template v-else-if="mod.countries === 'es'">
          <img v-if="mod.countries" class="h-5 border border-black dark:border-white" src="../assets/es.png" />
        </template>
        <template v-else-if="mod.countries === 'jp'">
          <img v-if="mod.countries" class="h-5 border border-black dark:border-white" src="../assets/jp.png" />
        </template>
        <template v-else-if="mod.countries === 'cn'">
          <img v-if="mod.countries" class="h-5 border border-black dark:border-white" src="../assets/cn.png" />
        </template>
        <template v-else>
          <img v-if="mod.countries" class="h-5 border border-black dark:border-white" src="../assets/en.png" />
        </template>
      </div>

      <!-- Author -->
      <a v-if="mod.author" @click.prevent="openLink(`https://github.com/${mod.author}`)"
         class="cursor-pointer w-fit">
        {{ mod.author }}
      </a>

      <template v-if="version">
        <!-- Version -->
        <a v-if="mod.author && mod.githubLink && version.version"
           @click.prevent="openLink(`https://github.com/${mod.author}/${mod.github}/releases/tag/${version.version}`)"
           class="cursor-pointer w-fit">
          Version: <span class="text-blue-400">{{ version.version }}</span>
        </a>

        <!-- Game Version -->
        <p v-if="version.gameVersion" class="w-fit">
          Game Version: <span class="text-blue-400">{{ version.gameVersion }}</span>
        </p>
      </template>

    </div>
    <!-- Div bas -->
    <div class="flex flex-col gap-1">
      <!-- Buttons -->
      <div class="flex justify-between items-center gap-4">
        <div class="flex items-center gap-2">
          <template v-if="version">
            <template v-if="!isInstalledMod(mod.sid, version.version)">
              <template v-if="canBeUpdated(mod.sid, version.version) === true">
                <div @click="() => downloadMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/update.png"/></div>
                <div @click="() => uninstallMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/delete.png"/></div>
              </template>
              <template v-else>
                <div @click="() => downloadMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/download.png"/></div>
              </template>
            </template>
            <template v-else>
              <div @click="() => startMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/play.png"/></div>
              <div @click="() => uninstallMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/delete.png"/></div>
            </template>

            <template v-if="isFavoriteMod(mod.sid, version.version)">
              <div @click="() => removeFavoriteMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/favoriteFilled.png"/></div>
            </template>
            <template v-else>
              <div @click="() => addFavoriteMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/favorite.png"/></div>
            </template>
            <div @click="() => addShortcut(mod, version)"><img class="image-icon cursor-pointer" src="../assets/shortcut.png"/></div>
          </template>
          <template v-else>
            <template v-if="!isInstalledMod(mod.sid)">
              <div @click="() => downloadMod(mod)"><img class="image-icon cursor-pointer" src="../assets/download.png"/></div>
            </template>
            <template v-else>
              <div @click="() => startMod(mod)"><img class="image-icon cursor-pointer" src="../assets/play.png"/></div>
              <div @click="() => uninstallMod(mod)"><img class="image-icon cursor-pointer" src="../assets/delete.png"/></div>
            </template>

            <template v-if="isFavoriteMod(mod.sid)">
              <div @click="() => removeFavoriteMod(mod)"><img class="image-icon cursor-pointer" src="../assets/favoriteFilled.png"/></div>
            </template>
            <template v-else>
              <div @click="() => addFavoriteMod(mod)"><img class="image-icon cursor-pointer" src="../assets/favorite.png"/></div>
            </template>
          </template>
        </div>
        <div class="flex items-center gap-2">
          <a v-if="mod.githubLink" @click.prevent="openLink(`https://github.com/${mod.author}/${mod.github}`)" class="cursor-pointer">
            <img class="image-icon" src="../assets/github.png" />
          </a>
          <a v-if="mod.social" @click.prevent="openLink(`${mod.social}`)" class="cursor-pointer">
            <img class="image-icon" src="../assets/discord.png" />
          </a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    mod: {
      type: Object,
      required: true,
    },
    version: {
      type: Object,
      required: false
    }
  },
  methods: {
    openLink(url) {
      window.electronAPI.openExternal(url);
    },
    downloadMod(mod, version = null) {
      window.electronAPI.sendData('downloadMod', JSON.stringify(mod), JSON.stringify(version));
    },
    uninstallMod(mod, version = null) {
      window.electronAPI.sendData('uninstallMod', JSON.stringify(mod), JSON.stringify(version));
    },
    startMod(mod, version = null) {
      window.electronAPI.sendData('startMod', JSON.stringify(mod), JSON.stringify(version));
    },
    addFavoriteMod(mod, version = null) {
      window.electronAPI.sendData('addFavoriteMod', JSON.stringify(mod), JSON.stringify(version));
    },
    removeFavoriteMod(mod, version = null) {
      window.electronAPI.sendData('removeFavoriteMod', JSON.stringify(mod), JSON.stringify(version));
    },
    isInstalledMod(modId, version = null) {
      return this.$store.getters.isInstalledMod(modId, version);
    },
    isFavoriteMod(modId, version = null) {
      return this.$store.getters.isFavoriteMod(modId, version);
    },
    canBeUpdated(modId, version = null) {
      return this.$store.getters.canBeUpdated(modId, version);
    },
    addShortcut(mod, version = null) {
      window.electronAPI.sendData('addShortcut', JSON.stringify(mod), JSON.stringify(version));
    }
  },
};
</script>