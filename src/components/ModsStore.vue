<template>
  <div class="page p-4">
    <div class="flex flex-col gap-4">
      <div class="flex items-center gap-4">
        <img class="w-12 h-12" src="../assets/mods.png" />
        <h1 class="text-4xl font-bold tracking-widest">Mods Store</h1>         
      </div>
      <div>
    <!-- Filtre pour l'auteur -->
    <select v-model="selectedAuthor">
      <option value="">Tous les auteurs</option>
      <option v-for="author in authorOptions" :key="author" :value="author">{{ author }}</option>
    </select>

    <!-- Filtre pour la version du jeu -->
    <select v-model="selectedGameVersion">
      <option value="">Toutes les versions</option>
      <option v-for="version in gameVersionOptions" :key="version" :value="version">{{ version }}</option>
    </select>

    <!-- Contenu filtré -->
    <div v-for="mod in filteredMods" :key="mod.sid">
      <!-- Affichage des détails du mod -->
    </div>
  </div>
      <div v-if="$store.state.appData && $store.state.appData.modSources" class="flex flex-col gap-4">
        <div class="border rounded flex flex-col gap-1 p-4 bg-gray-700" v-for="mod in filteredMods" :key="mod.sid">
          <p class="uppercase text-lg">{{ mod.name }}</p>
          <p>{{ mod.author }}</p>
          <p>{{ mod.gameVersion }}</p>
          <div class="flex items-center gap-1">
            <a href=""><img class="h-6 w-6" src="../assets/download.png" /></a>
          <a href=""><img class="h-6 w-6" src="../assets/play.png" /></a>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      // ...autres données
      selectedAuthor: '',
      selectedGameVersion: '',
      authorOptions: ['Auteur 1', 'Auteur 2', 'Auteur 3'], // Exemple d'options d'auteurs
      gameVersionOptions: ['Version 1', 'Version 2', 'Version 3'] // Exemple d'options de versions de jeu
    };
  },
  computed: {
    filteredMods() {
      return this.$store.getters.filteredMods(this.filterName, this.filterAuthor, this.filterGameVersion);
    }
  }
};
</script>
