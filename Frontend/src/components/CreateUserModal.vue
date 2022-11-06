<template>
  <div
    class="modal fade"
    id="createUserModal"
    tabindex="-1"
    aria-labelledby="createUserModalLabel"
    aria-hidden="true"
  >
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="createUserModalLabel">Create New User</h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body">
          <form>
            <div class="form-group">
              <label for="username">username:</label>
              <input
                type="text"
                id="username"
                v-model="Username"
                class="form-control"
                placeholder="Username..."
              />
            </div>
            <div class="form-group">
              <label for="firstName">First Name:</label>
              <input
                type="text"
                id="firstName"
                v-model="FirstName"
                class="form-control"
                placeholder="First Name..."
              />
            </div>
            <div class="form-group">
              <label for="lastName">Last Name:</label>
              <input
                type="text"
                id="lastName"
                v-model="LastName"
                class="form-control"
                placeholder="Last Name..."
              />
            </div>
            <div class="form-group">
              <label for="email">Email:</label>
              <input
                type="text"
                id="email"
                v-model="Email"
                class="form-control"
                placeholder="Email..."
              />
            </div>
            <div class="form-group">
              <label for="role">Role:</label>
              <input type="radio" v-model="Role" id="role" value="Admin"/>
              <label for="admin">Admin</label>

              <input type="radio" v-model="Role" id="role" value="User"/>
              <label for="user">User</label>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
          <button type="button" class="btn btn-save" data-bs-dismiss="modal" @click="onSubmit()">
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { inject } from '@vue/runtime-core';
import { User} from '../models/User'

export default {
  setup() {
    const service = inject('service');
    const { createUser } = service();

    const onSubmit = function () {
       const Username = document.getElementById('username').value;
       const FirstName = document.getElementById('firstName').value;
       const LastName = document.getElementById('lastName').value;
       const Email = document.getElementById('email').value;
       const Role = document.getElementById('role').value;

      const userData = new User(Username, FirstName, LastName, Email, Role);
      createUser(userData);
    };

    return {
      onSubmit
    };
  },
};
</script>

<style scoped>
.btn-save {
  background: rgba(106, 0, 255, 1);
  color: white;
}

.btn-save:hover {
  filter: brightness(1.2);
}
</style>
