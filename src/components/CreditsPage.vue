<template>
  <div class="page p-4">
    <div class="flex flex-col gap-4">
      <div class="flex items-center gap-4">
        <img class="image-title" src="../assets/credits.png" />
        <h1 class="title">{{ $t('Credits') }}</h1>
      </div>
      <div class="flex items-center flex-wrap py-4">
        <p class="text-sm">{{ $store.state.appData.modSources[0].credits }}</p>
      </div>
    </div>
  </div>
</template>

<script>
</script>
