<template>
  <div class="about">
    <GuestInfo />
  </div>
</template>

<script>
// @ is an alias to /src
import GuestInfo from '@/components/GuestInfo.vue'

export default {
  name: 'about',
  components: {
    GuestInfo
  }
}
</script>
