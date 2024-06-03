<template>
  <div class="flex justify-center items-center fixed top-0 left-0 w-full h-full z-10"
       style="background: rgba(0, 0, 0, 0.5)" v-if="visible">
    <div class="flex flex-col gap-4 bg-gray-600 p-5 rounded text-center">
      <p class="title">{{ $t(message) }}</p>
      <div class="flex justify-center items-center gap-4">
        <button class="button" @click="confirm">{{ $t('Yes') }}</button>
        <button class="button" @click="cancel">{{ $t('No') }}</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    visible: {
      type: Boolean,
      default: false
    },
    message: {
      type: String,
      default: "Are you sure?"
    }
  },
  methods: {
    confirm() {
      this.$emit('confirm');
    },
    cancel() {
      this.$emit('cancel');
    }
  }
}
</script>
