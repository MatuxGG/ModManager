<template>
  <div class="page p-4">
    <div class="flex flex-col items-center justify-center gap-4">
      <img class="w-36" src="../assets/modmanager.png" />
      <div class="flex items-center gap-4">
        <span><div class="lds-ring"><div></div><div></div><div></div><div></div></div></span>
        <h1 class="title">{{ $t('Loading...') }}</h1>
      </div>
    </div>
  </div>
</template>

<style>
.lds-ring {
  display: inline-block;
  position: relative;
  width: 80px;
  height: 80px;
}
.lds-ring div {
  box-sizing: border-box;
  display: block;
  position: absolute;
  width: 64px;
  height: 64px;
  margin: 8px;
  border: 8px solid #fff;
  border-radius: 50%;
  animation: lds-ring 1.2s cubic-bezier(0.5, 0, 0.5, 1) infinite;
  border-color: #fff transparent transparent transparent;
}
.lds-ring div:nth-child(1) {
  animation-delay: -0.45s;
}
.lds-ring div:nth-child(2) {
  animation-delay: -0.3s;
}
.lds-ring div:nth-child(3) {
  animation-delay: -0.15s;
}
@keyframes lds-ring {
  0% {
    transform: rotate(0deg);
  }
  100% {
    transform: rotate(360deg);
  }
}

</style>

<script>
</script>
