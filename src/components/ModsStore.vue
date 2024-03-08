<template>
  <div class="page p-4">
      <div class="flex flex-col gap-4">
          <div class="flex items-center gap-4">
              <img class="image-title" src="../assets/download.png"/>
              <h1 class="title">Mods Store</h1>
          </div>
          <div class="flex items-center gap-4">
            <select v-model="selectedCategory" class="selectbox">
              <option value="">All categories</option>
              <option v-for="category in categoriesOptions" :key="category.sid" :value="category.sid">{{ category.name }}</option>
            </select>
            <select v-model="selectedGameVersion" class="selectbox">
              <option value="">All versions</option>
              <option v-for="version in gameVersionOptions" :key="version" :value="version">{{ version }}</option>
            </select>
          </div>
          <div v-if="$store.state.appData && $store.state.appData.modSources" class="flex flex-wrap gap-4">
            <template v-for="mod in filteredMods"
                  :key="mod.sid">
              <!-- All In One -->
              <template v-if="mod.type === 'allInOne'">
                <div class="border rounded flex flex-col justify-between gap-4 p-4 bg-gray-300 dark:bg-gray-700 min-w-[300px]" >
                  <!-- Div haut-->
                  <div class="flex flex-col gap-1">
                    <!-- Ligne titre + flag-->
                    <div class="flex items-center gap-4 justify-between">
                      <p class="uppercase text-lg cursor-pointer">{{ mod.name }}</p>
                      <template v-if="mod.countries === 'fr'">
                        <img class="h-6 border border-white" src="../assets/fr.png" />
                      </template>
                      <template v-else-if="mod.countries === 'es'">
                        <img v-if="mod.countries" class="h-6 border border-white" src="../assets/es.png" />
                      </template>
                      <template v-else-if="mod.countries === 'jp'">
                        <img v-if="mod.countries" class="h-6 border border-white" src="../assets/jp.png" />
                      </template>
                      <template v-else-if="mod.countries === 'cn'">
                        <img v-if="mod.countries" class="h-6 border border-white" src="../assets/cn.png" />
                      </template>
                      <template v-else>
                        <img v-if="mod.countries" class="h-6 border border-white" src="../assets/en.png" />
                      </template>
                    </div>
                    <a v-if="mod.author" @click.prevent="openLink(`https://github.com/${mod.author}`)" class="cursor-pointer">
                      {{ mod.author }}
                    </a>
                  </div>
                  <!-- Div bas -->
                  <div class="flex flex-col justify-between gap-1">
                    <!-- Buttons-->
                    <div class="flex justify-between items-center gap-4">
                      <div class="flex items-center gap-2">
                        <template v-if="1">
                          <a href=""><img class="image-icon" src="../assets/download.png"/></a>
                        </template>
                        <template v-if="0">
                          <a href=""><img class="image-icon" src="../assets/play.png"/></a>
                        </template>
                        <template v-if="0">
                          <a href=""><img class="image-icon" src="../assets/delete.png"/></a>
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
              <!-- Mod -->
              <template v-for="version in mod.versions" :key="version.version">
                <template v-if="selectedGameVersion === '' || selectedGameVersion === version.gameVersion">
                  <div class="border rounded flex flex-col justify-between gap-4 p-4 bg-gray-300 dark:bg-gray-700 min-w-[300px]" >
                    <!-- Div haut -->
                    <div class="flex flex-col gap-1">
                      <!-- Ligne titre + flag -->
                      <div class="flex items-center gap-4 justify-between">
                        <p class="uppercase text-lg cursor-pointer">{{ mod.name }}</p>
                        <template v-if="mod.countries === 'fr'">
                          <img class="h-6 border border-black dark:border-white" src="../assets/fr.png" />
                        </template>
                        <template v-else-if="mod.countries === 'es'">
                          <img v-if="mod.countries" class="h-6 border border-black dark:border-white" src="../assets/es.png" />
                        </template>
                        <template v-else-if="mod.countries === 'jp'">
                          <img v-if="mod.countries" class="h-6 border border-black dark:border-white" src="../assets/jp.png" />
                        </template>
                        <template v-else-if="mod.countries === 'cn'">
                          <img v-if="mod.countries" class="h-6 border border-black dark:border-white" src="../assets/cn.png" />
                        </template>
                        <template v-else>
                          <img v-if="mod.countries" class="h-6 border border-black dark:border-white" src="../assets/en.png" />
                        </template>
                      </div>
                      <a v-if="mod.author" @click.prevent="openLink(`https://github.com/${mod.author}`)" class="cursor-pointer">
                        {{ mod.author }}
                      </a>
                      <a v-if="mod.author && mod.githubLink && version.version" @click.prevent="openLink(`https://github.com/${mod.author}/${mod.github}/releases/tag/${version.version}`)" class="cursor-pointer">
                        Version: {{ version.version }}
                      </a>
                    </div>
                    <!-- Div bas -->
                    <div class="flex flex-col gap-1">
                      <!-- Buttons -->
                      <div class="flex justify-between items-center gap-4">
                        <div class="flex items-center gap-2">
                          <template v-if="1">
                            <div @click="() => downloadMod(mod, version)"><img class="image-icon cursor-pointer" src="../assets/download.png"/></div>
                          </template>
                          <template v-if="0">
                            <a href=""><img class="image-icon" src="../assets/play.png"/></a>
                          </template>
                          <template v-if="0">
                            <a href=""><img class="image-icon" src="../assets/delete.png"/></a>
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
              </template>
            </template>
          </div>
      </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        selectedGameVersion: '',
        selectedCategory: '',
      };
    },
    computed: {
      categoriesOptions() {
        return this.$store.getters.categoriesOptions;
      },
      gameVersionOptions() {
        return this.$store.getters.gameVersionOptions;
      },
      filteredMods() {
        return this.$store.getters.filteredMods(this.selectedCategory, this.selectedGameVersion);
      }
    },
    mounted() {
      if (this.categoriesOptions.length > 1) {
        this.selectedCategory = this.categoriesOptions[0].sid;
      }
    },
    methods: {
      openLink(url) {
        window.electronAPI.openExternal(url);
      },
      downloadMod(mod, version) {
        window.electronAPI.sendData('downloadMod', JSON.stringify(mod), JSON.stringify(version));
      }
    },
  };
</script>
