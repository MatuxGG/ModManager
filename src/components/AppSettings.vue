<template>
  <div class="page p-4">
    <div class="flex flex-col gap-4">
      <!-- En-tête des paramètres -->
      <div class="flex items-center gap-4">
        <img class="image-title" src="../assets/settings.png" />
        <h1 class="title">Settings</h1>         
      </div>

      <h2 class="title2">General</h2>

      <div class="flex items-center text-xl">
        <label class="min-w-[200px]" for="language-selector">Select Language:</label>
        <select class="selectbox" id="language-selector" v-model="selectedLanguage">
          <option value="EN">English</option>
          <option value="FR">Français</option>
        </select>
      </div>

      <div class="flex items-center text-xl">
        <label for="minimize-to-tray" class="min-w-[200px] cursor-pointer">Minimize to tray</label>
        <input type="checkbox" id="minimize-to-tray" v-model="minimizeToTray">
      </div>

      <div class="flex items-center text-xl">
        <label for="launch-on-startup" class="min-w-[200px] cursor-pointer">Launch on startup</label>
          <input type="checkbox" id="launch-on-startup" v-model="launchOnStartup">
      </div>

      <h2 class="title2">Appearance</h2>

      <div class="flex items-center text-xl">
        <label class="min-w-[200px]" for="theme-selector">Theme:</label>
        <select class="selectbox" id="theme-selector" v-model="selectedTheme">
          <option value="dark">Dark</option>
          <option value="light">Light</option>
        </select>
      </div>

      <h2 class="title2">Support</h2>

      <div class="flex items-center text-xl">
        <p class="min-w-[200px]">Copy Support ID:</p>
        <button class="button" @click="copySupportId">Copy Support ID</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      selectedLanguage: this.$store.state.appData.config.lg,
      selectedTheme: this.$store.state.appData.config.theme,
      minimizeToTray: this.$store.state.appData.config.minimizeToTray,
      launchOnStartup: this.$store.state.appData.config.launchOnStartup,
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
      this.$store.state.appData.config.minimizeToTray = newValue;
      window.electronAPI.sendData('updateConfigServer', JSON.stringify(this.$store.state.appData.config));
    },
    launchOnStartup(newValue) {
      this.$store.state.appData.config.launchOnStartup = newValue;
      window.electronAPI.sendData('updateConfigServer', JSON.stringify(this.$store.state.appData.config));
    },
    selectedLanguage(newValue) {
      this.$store.state.appData.config.lg = newValue;
      window.electronAPI.sendData('updateConfigServer', JSON.stringify(this.$store.state.appData.config));
    },
    selectedTheme(newValue) {
      this.$store.state.appData.config.theme = newValue;
      window.electronAPI.sendData('updateConfigServer', JSON.stringify(this.$store.state.appData.config));
    },
  },
  mounted() {
    // Chargement de la configuration existante et définition des données
    // this.loadSettings();
  }
};
</script>
