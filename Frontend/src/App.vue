<template>
  <Suspense>
    <Home />
  </Suspense>
  <CreateUserModal />
</template>

<script setup>
import Home from './components/Home.vue';
import CreateUserModal from './components/CreateUserModal.vue';
import { provide } from '@vue/runtime-core';

import service from './service';
provide('service', service);

</script>

<style>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

:root {
  --black1: #30333d;
  --purple1: #6a00ffb3;
  --purple2: #e9eff4;
  --gray1: #a4acb2;
}

.main {
  position: relative;
}

a {
  text-decoration: none;
}

html,
body {
  height: 100%;
}

body {
  scroll-behavior: smooth;
  font-family: 'fangsong';
  font-display: auto;
  overflow: hidden;
}
</style>
