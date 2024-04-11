<template>
  <div class="page p-4">
    <div class="flex flex-col gap-2">
      <!-- En-tête des paramètres -->
      <div class="flex items-center gap-2">
        <img class="image-title" src="../assets/settings.png" />
        <h1 class="title">{{ $t('settings.title') }}</h1>
      </div>

      <h2 class="title2">{{ $t('settings.general') }}</h2>

      <div class="flex items-center text-sm">
        <label class="min-w-[300px]" for="language-selector">{{ $t('settings.select_language') }}</label>
        <select class="selectbox" id="language-selector" v-model="selectedLanguage">
          <option value="en">English</option>
          <option value="fr">Français</option>
        </select>
      </div>

      <div class="flex items-center text-sm">
        <label for="minimize-to-tray" class="min-w-[300px] cursor-pointer">{{ $t('settings.minimize') }}</label>
        <input type="checkbox" id="minimize-to-tray" v-model="minimizeToTray">
      </div>

      <div class="flex items-center text-sm">
        <label for="launch-on-startup" class="min-w-[300px] cursor-pointer">{{ $t('settings.startup') }}</label>
          <input type="checkbox" id="launch-on-startup" v-model="launchOnStartup">
      </div>

      <h2 class="title2">{{ $t('settings.appearance') }}</h2>

      <div class="flex items-center text-sm">
        <label class="min-w-[300px]" for="theme-selector">{{ $t('settings.theme') }}</label>
        <select class="selectbox" id="theme-selector" v-model="selectedTheme">
          <option value="dark">{{ $t('settings.dark') }}</option>
          <option value="light">{{ $t('settings.light') }}</option>
        </select>
      </div>

      <h2 class="title2">{{ $t('settings.support') }}</h2>

      <div class="flex items-center text-sm">
        <p class="min-w-[300px]">{{ $t('settings.copy_support_id_title') }}</p>
        <button class="button" @click="copySupportId">{{ $t('settings.copy_support_id') }}</button>
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
      this.$i18n.locale = this.$store.state.appData.config.lg;
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
