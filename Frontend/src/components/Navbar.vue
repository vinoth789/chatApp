<template>
  <div class="navbar navbar-expand navbar-dark bg-dark fixed-header">
    <a href="/">
      <h2 class="title">Chat Room</h2>
    </a>
    <a v-if="hidden" class="username fw-bold"><img :src="avatarElite" width="25" height="25" alt="avatar" />
    {{currentUser.username}}</a>
    <a class="title" v-if="hidden" href="/"> Logout <img :src="logout" width="25" height="25" alt="avatar" /></a>
  </div>
</template>

<script>
import logout from '../assets/logout.svg';
import avatarElite from '../assets/avatarElite.svg';
import { inject } from '@vue/runtime-core';

export default {
  name: 'Navbar',
  props: {
    hidden: Boolean,
    username: String
  },
  async setup() {
    const service = inject('service');
    const { currentUser } = service();
    return {
      logout,
      currentUser,
      avatarElite
    };
  }
};
</script>

<style scoped>
h2 {
  font-weight: 600;
}

a:hover {
  color: whitesmoke;
}

.username {
  margin-left: 68em;
  color: whitesmoke;
  padding: 0.5em 1em;
}

.title {
  color: whitesmoke;
  font-family: fangsong;
}

.navbar {
  padding: 0.5em 1em;
}
</style>
