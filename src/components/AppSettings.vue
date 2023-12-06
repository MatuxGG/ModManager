<template>
  <div class="page p-4">
    <div class="flex flex-col gap-4">
      <!-- En-tête des paramètres -->
      <div class="flex items-center gap-4">
        <img class="w-12 h-12" src="../assets/settings.png" />
        <h1 class="title">Settings</h1>         
      </div>

      <h2 class="title2">General</h2>

      <div class="flex items-center text-xl">
        <label class="min-w-[200px]" for="language-selector">Select Language:</label>
        <select class="mm-selectbox" id="language-selector" v-model="$store.state.appData.config.lg">
          <option value="EN">English</option>
          <option value="FR">Français</option>
        </select>
      </div>

      <div class="flex items-center text-xl">
        <label for="minimize-to-tray" class="min-w-[200px] cursor-pointer">Minimize to tray</label>
        <input type="checkbox" id="minimize-to-tray" v-model="$store.state.appData.config.minimizeToTray">
      </div>

      <div class="flex items-center text-xl">
        <label for="launch-on-startup" class="min-w-[200px] cursor-pointer">Launch on startup</label>
          <input type="checkbox" id="launch-on-startup" v-model="$store.state.appData.config.launchOnStartup">
      </div>

      <h2 class="title2">Appearance</h2>

      <div class="flex items-center text-xl">
        <label class="min-w-[200px]" for="theme-selector">Theme:</label>
        <select class="mm-selectbox" id="theme-selector" v-model="$store.state.appData.config.theme">
          <option value="dark">Dark</option>
          <option value="light" disabled>Light</option>
        </select>
      </div>

      <h2 class="title2">Support</h2>

      <div class="flex items-center text-xl">
        <p class="min-w-[200px]">Copy Support ID:</p>
        <button class="mm-button" @click="copySupportId">Copy Support ID</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      supportId: this.$store.state.appData.config.supportId,
    };
  },
  methods: {
    copySupportId() {
      if (navigator.clipboard && window.isSecureContext) {
        // Utiliser clipboard API quand disponible
        return navigator.clipboard.writeText(this.supportId);
      } else {
        // Autre méthode pour les navigateurs plus anciens
        let textArea = document.createElement("textarea");
        textArea.value = this.supportId;
        document.body.appendChild(textArea);
        textArea.focus();
        textArea.select();
        try {
          document.execCommand('copy');
          alert('Support ID copied to clipboard');
        } catch (err) {
          console.error('Unable to copy to clipboard', err);
        }
        document.body.removeChild(textArea);
      }
    }
  },
  // Ajoutez d'autres méthodes si nécessaire pour gérer les paramètres
  watch: {
    minimizeToTray(newValue) {
      console.log('Minimize to tray option changed:', newValue);
    },
    launchOnStartup(newValue) {
      console.log('Launch on startup option changed:', newValue);
    },
    selectedLanguage(newValue) {
      console.log('Language changed to:', newValue);
    }
  },
  mounted() {
    // Chargement de la configuration existante et définition des données
    // this.loadSettings();
  }
};
</script>
