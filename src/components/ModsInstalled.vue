<template>
  <div class="page p-4">
    <div class="flex flex-col gap-4">
      <div class="flex items-center gap-4">
        <img class="image-title" src="../assets/mods.png" />
        <h1 class="title">Mods Installed</h1>
      </div>
      <div class="flex items-center flex-wrap">
        <div v-if="!$store.state.appData.config.installedMods || $store.state.appData.config.installedMods.length == 0" class="pt-8 flex flex-col gap-4">
          <p class="text-lg">You don't have any mod yet.</p>
          <a class="text-lg link" href="/store">Download one here !</a>
        </div>
        <div v-else class="">
            Mods installés...
        </div>
      </div>
    </div>
  </div>
</template>

<script>
</script>
