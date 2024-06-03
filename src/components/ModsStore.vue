<template>
  <div class="page p-4">
      <div class="flex flex-col gap-4">
          <div class="flex items-center gap-4">
              <img class="image-title" src="../assets/download.png"/>
              <h1 class="title">{{ $t('Mods store') }}</h1>
          </div>
          <div class="flex items-center gap-4">
            <select v-model="selectedCategory" class="selectbox">
              <option value="">{{ $t('All categories') }}</option>
              <option v-for="category in categoriesOptions" :key="category.sid" :value="category.sid">{{ $t(category.name) }}</option>
            </select>
            <select v-model="selectedGameVersion" class="selectbox">
              <option value="">{{ $t('All versions') }}</option>
              <option v-for="version in gameVersionOptions" :key="version" :value="version">{{ version }}</option>
            </select>
            <select v-model="installedType" class="selectbox">
              <option value="ALL" selected="selected">{{ $t('All mods') }}</option>
              <option value="ONLY_INSTALLED">{{ $t('Only installed mods') }}</option>
              <option value="ONLY_NOT_INSTALLED">{{ $t('Only not installed mods') }}</option>
            </select>
            <input type="text" v-model="searchOption" class="searchbox" :placeholder="$t('Search...')">
          </div>
          <div v-if="$store.state.appData && $store.state.appData.modSources" class="flex flex-wrap gap-4">
            <template v-for="mod in filteredMods"
                  :key="mod.sid">
              <template v-if="mod.type === 'allInOne'">
                <template v-if="(this.installedType !== 'ONLY_INSTALLED' || this.isInstalledMod(mod.sid)) && (this.installedType !== 'ONLY_NOT_INSTALLED' || !this.isInstalledMod(mod.sid))">
                  <ModCard :mod="mod" />
                </template>
              </template>
              <template v-else>
                <template v-for="version in mod.versions" :key="version.version">
                  <template v-if="(selectedGameVersion === '' || selectedGameVersion === version.gameVersion) && (this.installedType !== 'ONLY_INSTALLED' || this.isInstalledMod(mod.sid, version.version)) && (this.installedType !== 'ONLY_NOT_INSTALLED' || !this.isInstalledMod(mod.sid, version.version))">
                    <ModCard :mod="mod" :version="version" />
                  </template>
                </template>
              </template>
            </template>
          </div>
      </div>
  </div>
</template>

<script>
  import ModCard from './ModCard.vue';

  export default {
    components: {
      ModCard
    },
    data() {
      return {
        selectedGameVersion: '',
        selectedCategory: '',
        installedType : "ALL",
        searchOption: '',
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
      }
    },
  };
</script>
