<template>
  <div class="col-2 d-flex flex-column p-0 users" style="background-color: #9388AD;">
    <div class="d-flex flex-row justify-content-between mx-1 mb-4 m-2 w-90">
        <h5 class="title">Users</h5>
    </div>
    <div class="card" style="background-color: #341948">
    <a
      v-for="user in users"
      :key="user.id"
      class="profile p-1 m-2 mx-2 d-flex flex-row align-items-center gap-2">
      <img :src="avatar" width="38" height="38" alt="avatar" />
      <span class="fw-bold">{{ user.username }}</span>
    </a>
  </div>
  </div>
</template>

<script>
import { inject } from '@vue/runtime-core';
import avatar from '../assets/avatar.svg';

export default {
  name: 'Users',
  setup() {
    const service = inject('service');

    const { users } = service();

    return {
      avatar,
      users,
    };
  },
     }

</script>

<style scoped>
.users {
  background: #ffffff;
}

a {
  color: whitesmoke;
} 

.title {
  font-weight: bold;
  color: black;
  padding: 10px 70px;
}

.profile span {
  overflow: hidden;
  white-space: nowrap;
  text-overflow: ellipsis;
}

@media screen and (max-width: 968px) {
  .users {
    position: absolute;
    top: 0;
    right: 0;
    width: 16rem;
    height: 100vh;
    filter: drop-shadow(-5px 0 20px #aaaaaa);
    z-index: 2;
  }

  .users.hide {
    display: none !important;
  }
}
</style>
