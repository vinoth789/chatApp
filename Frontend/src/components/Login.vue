<template>
  <form class="d-flex flex-column justify-content-center align-items-center h-75">
    <div class="form-group mt-25">
      <label for="uid">User ID</label>
      <input
        type="text"
        class="form-control"
        id="uid"
        placeholder="Type 1,2 and so on..."
        required="true"
      />
      <div class="buttons">
      <input class="btn btn-primary" type="submit" @click="login" value="Login" />
      <button class="btn btn-secondary" style="margin-left:10px;" data-bs-toggle="modal" data-bs-target="#createUserModal">Register</button>
    </div>
    </div>
  </form>
</template>

<script>
import { inject } from '@vue/runtime-core';

export default {
   setup() {
     const service = inject('service');
     const { setUser } = service();

     const login = function (e) {
       e.preventDefault();

       const input = document.getElementById('uid');

       if (input && input?.value !== '') {
         setUser(input.value);
       }
     };

     return {
       login,
     };
   }
};
</script>

<style scoped>
.buttons {
  padding: 10px;
}

.btn:hover {
  filter: brightness(1.2);
}

</style>
