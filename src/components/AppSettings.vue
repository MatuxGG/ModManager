<template>
  <ConfirmPopin
    :visible="showResetPopin"
    :message="`mod_manager_reset_close`"
    @confirm="confirmReset"
    @cancel="cancelReset"
  />
  <div class="page p-4">
    <div class="flex flex-col gap-2">
      <!-- En-tête des paramètres -->
      <div class="flex items-center gap-2">
        <img class="image-title" src="../assets/settings.png" />
        <h1 class="title">{{ $t('Settings') }}</h1>
      </div>

      <h2 class="title2">{{ $t('General') }}</h2>

      <div class="flex items-center text-sm">
        <label class="min-w-[300px]" for="language-selector">{{ $t('Select Language:') }}</label>
        <select class="selectbox" id="language-selector" v-model="selectedLanguage">
          <option v-for="lang in languages" :key="lang.code" :value="lang.code.toLowerCase()">
            {{ lang.name }}
          </option>
        </select>
      </div>

      <div class="flex items-center text-sm">
        <label for="minimize-to-tray" class="min-w-[300px] cursor-pointer">{{ $t('Minimize on startup:') }}</label>
        <input type="checkbox" id="minimize-to-tray" v-model="minimizeToTray">
      </div>

      <div class="flex items-center text-sm">
        <label for="launch-on-startup" class="min-w-[300px] cursor-pointer">{{ $t('Launch on startup:') }}</label>
          <input type="checkbox" id="launch-on-startup" v-model="launchOnStartup">
      </div>

      <h2 class="title2">{{ $t('Appearance') }}</h2>

      <div class="flex items-center text-sm">
        <label class="min-w-[300px]" for="theme-selector">{{ $t('Theme:') }}</label>
        <select class="selectbox" id="theme-selector" v-model="selectedTheme">
          <option value="dark">{{ $t('Dark') }}</option>
          <option value="light">{{ $t('Light') }}</option>
        </select>
      </div>

      <h2 class="title2">{{ $t('Data') }}</h2>

      <div class="flex items-center text-sm">
        <label for="minimize-to-tray" class="min-w-[300px] cursor-pointer">{{ $t('Data path:') }}</label>
        <div class="flex items-center gap-1 w-full">
          <input type="text" id="data-path" class="input w-fit flex grow" v-model="dataPath">
          <button class="button w-fit" @click="chooseFolder">{{ $t('Choose folder') }}</button>
          <button class="button w-fit" @click="browseFolder">{{ $t('Browse') }}</button>
        </div>
      </div>

      <div class="flex items-center text-sm">
        <p class="min-w-[300px]">{{ $t('Reset:') }}</p>
        <button class="button" @click="reset">{{ $t('Reset') }}</button>
      </div>

      <h2 class="title2">{{ $t('Support') }}</h2>

      <div class="flex items-center text-sm">
        <p class="min-w-[300px]">{{ $t('Copy support ID:') }}</p>
        <button class="button" @click="copySupportId">{{ $t('Copy support ID') }}</button>
      </div>
    </div>
  </div>
</template>

<script>

import ConfirmPopin from "./ConfirmPopin.vue";

export default {
  components: {ConfirmPopin},
  data() {
    return {
      selectedLanguage: this.$store.state.appData.config.lg,
      selectedTheme: this.$store.state.appData.config.theme,
      minimizeToTray: this.$store.state.appData.config.minimizeToTray,
      launchOnStartup: this.$store.state.appData.config.launchOnStartup,
      dataPath: this.$store.state.appData.config.dataPath,
      supportId: this.$store.state.appData.config.supportId,
      showResetPopin: false,
      languages: this.$languages
    };
  },
  methods: {
    copySupportId() {
      navigator.clipboard.writeText(this.supportId);
      let downloadId = Date.now().toString();
      let text = this.$t('Support ID copied to clipboard');
      window.electronAPI.sendData('createPopin', text, downloadId, "bg-green-700")
      window.electronAPI.sendData('removePopin', downloadId)
    },
    reset() {
      this.showResetPopin = true;
    },
    confirmReset() {
      this.showResetPopin = false;
      window.electronAPI.sendData('resetApp');
    },
    cancelReset() {
      this.showResetPopin = false;
    },
    async chooseFolder() {
      let result = await window.electronAPI.openFolderDialog(this.dataPath);
      if (result) {
        this.dataPath = result;
      }
    },
    async browseFolder() {
      let result = await window.electronAPI.openFolderDialog();
      if (result) {
        this.dataPath = result;
      }
    },
  },
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
      window.electronAPI.sendData('updateTray');
    },
    selectedTheme(newValue) {
      this.$store.state.appData.config.theme = newValue;
      window.electronAPI.sendData('updateConfigServer', JSON.stringify(this.$store.state.appData.config));
    }
  }
};
</script>
