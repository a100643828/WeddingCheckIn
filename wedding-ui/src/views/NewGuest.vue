<template>
  <div class="newGuest" style="height: inherit;">
    <GuestCreate />
  </div>
</template>

<script>
// @ is an alias to /src
import GuestCreate from '@/components/GuestCreate.vue'

export default {
  name: 'newGuest',
  components: {
    GuestCreate
  }
}
</script>
