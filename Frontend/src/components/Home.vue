<template>
  <div class="jumbotron vh-100 d-flex flex-column">
    <Navbar :hidden="!hidden"/>
    <div class="main row h-100 m-0">
      <Login v-if="hidden" />
      {{ currentUser.value?.id }}
      <Suspense>
        <template  v-if="!hidden">
           <Users/> 
           <ChatScreen />   
        </template>
      </Suspense>
    </div>
  </div>
</template>

<script>
import Navbar from './Navbar.vue';
import Login from './Login.vue';
import ChatScreen from './ChatScreen.vue';
import Users from './Users.vue';
import { inject, onUpdated, ref } from '@vue/runtime-core';


export default {
  async setup() {
    const service = inject('service');
    const hidden = ref(true);
    const { currentUser } = service();

    onUpdated(() => {
      hidden.value = false;
    });

    return {
      currentUser,
      hidden,
    };
  },
  components: {
    ChatScreen,
    Users,
    Login,
    Navbar
  },
};
</script>
