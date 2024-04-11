<template>
  <div class="page p-4">
    <div class="flex flex-col gap-4">
      <div class="flex items-center gap-4">
        <img class="image-title" src="../assets/mods.png" />
        <h1 class="title">Mods Installed</h1>
      </div>
      <template v-if="!$store.state.appData || !$store.state.appData.config.installedMods || $store.state.appData.config.installedMods.length === 0">
        <div class="pt-8 flex flex-col gap-4">
          <p class="text-sm">You don't have any mod yet.</p>
          <router-link class="text-sm link" to="/store">Download one here !</router-link>
        </div>
      </template>
      <template v-else>
        <div class="flex items-center gap-4">
          <select v-model="selectedCategory" class="selectbox">
            <option value="">All categories</option>
            <option v-for="category in categoriesOptions" :key="category.sid" :value="category.sid">{{ category.name }}</option>
          </select>
          <select v-model="selectedGameVersion" class="selectbox">
            <option value="">All versions</option>
            <option v-for="version in gameVersionOptions" :key="version" :value="version">{{ version }}</option>
          </select>
          <input type="text" v-model="searchOption" class="searchbox" placeholder="Search...">
        </div>
        <div v-if="$store.state.appData && $store.state.appData.modSources" class="flex flex-wrap gap-4">
          <template v-for="mod in filteredMods"
                    :key="mod.sid">
            <template v-if="mod.type === 'allInOne'">
              <template v-if="this.isInstalledMod(mod.sid)">
                <ModCard :mod="mod" />
              </template>
            </template>
            <template v-else>
              <template v-for="version in mod.versions" :key="version.version">
                <template v-if="(this.isInstalledMod(mod.sid, version.version)) && (selectedGameVersion === '' || selectedGameVersion === version.gameVersion)">
                  <ModCard :mod="mod" :version="version" />
                </template>
              </template>
            </template>
          </template>
        </div>
      </template>
    </div>
  </div>
</template>

<script>
  import ModCard from "./ModCard.vue";

  export default {
    components: {
      ModCard
    },
    data() {
      return {
        selectedGameVersion: '',
        selectedCategory: '',
        searchOption: '',
      };
    },
    computed: {
      categoriesOptions() {
        return this.$store.getters.categoriesInstalledOptions;
      },
      gameVersionOptions() {
        return this.$store.getters.gameVersionInstalledOptions;
      },
      filteredMods() {
        return this.$store.getters.filteredMods(this.selectedCategory, this.selectedGameVersion, this.searchOption);
      },
    },
    mounted() {
      if (this.categoriesOptions.length > 1) {
        this.selectedCategory = this.categoriesOptions[0].sid;
      }
    },
    methods: {
      isInstalledMod(modId, version = null) {
        return this.$store.getters.isInstalledMod(modId, version);
      },
    },
  };
</script>
