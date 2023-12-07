<!-- <template>
  <div class="page p-4">
    <div class="flex flex-col gap-4">
      <div class="flex items-center gap-4">
        <img class="image-title" src="../assets/servers.png" />
        <h1 class="title">Servers</h1>         
      </div>
      <div class="flex flex-wrap gap-4">
        <div v-for="region in regions" :key="region.name" class="border rounded flex h-fit justify-start flex-col gap-2 p-4 bg-gray-300 dark:bg-gray-700 min-w-[300px]" >
          <p class="uppercase text-lg cursor-pointer">{{ region.name }}</p>
          <p>IP: {{ region.DefaultIp ? region.DefaultIp : region.name }}</p>
          <p>Port: {{ region.port }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>

export default {
  data() {
    return {
      regions: this.$store.state.appData.regionInfo.Regions,
    };
  },
  watch: {
    minimizeToTray(newValue) {
      this.$store.state.appData.config.minimizeToTray = newValue;
      window.electronAPI.sendData('updateConfigServer', JSON.stringify(this.$store.state.appData.config));
    },
  },
  mounted() {
      
  },
};
</script> -->
