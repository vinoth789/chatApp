<template>
  <div class="col-8 d-flex flex-column p-0 justify-content-between p-3 border border-top-0 chatScreen"
    style="background-color:lightgray;">
    <div class="card">
      <div class="d-flex flex-column justify-content-between chat" style="padding:10px;">
        <div class="d-flex flex-column m-auto text-center justify-content-center mb-2 header">
          <h2 class="fw-bold">Chats</h2>
          <p class="text-muted" v-if="messages.length === 0">
            Start chatting...
          </p>
        </div>
        <div class="messages">
          <div v-for="msg in messages" :key="msg.id" class="d-flex gap-2 w-75 mb-4 bubble"
            :class="{ self: currentUser.id === msg.userId }">
            <img :src="avatar" width="50" height="50" alt="avatar" />
            <div class="text">
              <div class="username fw-bold">{{ msg.username }}</div>
              <div class="createdTimestamp">{{ msg.createdTimestamp }}</div>
              <div class="chatfield p-2">
                <span>{{ msg.message }}</span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="chatbox-wrapper" style="padding:10px;">
        <input type="text" class="chatbox px-3 p-2" placeholder="Send a message..." @keyup.enter="userSendMsg" />
      </div>
    </div>
  </div>
</template>

<script>
import { inject, onUpdated } from '@vue/runtime-core';
import avatar from '../assets/avatar.svg';
import { Chat } from '../models/Chat'

export default {
  name: 'ChatScreen',
  async setup() {
    const service = inject('service');

    const { messages, currentUser, sendMessage } = service();

    onUpdated(() => scrollBottom());

    const scrollBottom = () => {
      const messages = document.getElementsByClassName('messages')[0];

      if (messages) {
        messages.scrollTop = messages.scrollHeight;
      }
    };

    const userSendMsg = (e) => {
      e.preventDefault();

      if (e.target.value === '') return;
      scrollBottom();
      const chatData = new Chat(currentUser.value.id, new Date(), e.target.value);
      sendMessage(chatData);

      e.target.value = '';
    };

    return {
      avatar,
      currentUser,
      messages,
      userSendMsg,
    };
  }
};
</script>

<style scoped>
.chatbox {
  outline: none;
  border: none;
  border-radius: 10px;
  font-size: 1rem;
  background: #f0f0f0;
  transition: 0.2s;
  color: var(--black2);
  width: 100%;
}

.header {
  width: 100%;
  border-bottom: 2px var(--gray1) solid;
}

h2 {
  color: var(--purple1);
}

.messages {
  position: relative;
  height: 70vh;
  width: 100%;
  padding-right: 2em;
  overflow: auto;
}

.messages::-webkit-scrollbar {
  background: #d8d6d6;
  width: 8px;
  border-radius: 5px;
}

.messages::-webkit-scrollbar-thumb {
  border-radius: 5px;
  background: var(--purple1);
}

.chatfield {
  background: var(--purple1);
  color: #f9fbfc;
  border-radius: 10px;
  border-top-left-radius: 0;
}

.createdTimestamp {
  font-style: italic;
  color: grey;
}

.chatbox:focus,
.self .chatfield {
  background: var(--purple2);
  color: var(--black1);
}

.self .chatfield {
  border-top-right-radius: 0;
  border-top-left-radius: 10px;
}

.chatfield {
  font-size: 1rem;
  width: fit-content;
}

.bubble {
  flex-flow: row;
}

.bubble.self {
  flex-flow: row-reverse;
}

.self .chatfield {
  float: right;
}

.self {
  text-align: right;
  float: right;
  flex-flow: row-reverse;
}

img {
  -webkit-user-drag: none;
}

@media screen and (max-width: 968px) {
  .chatScreen {
    position: fixed;
    width: 100%;
    height: calc(100% - 60px);
    background-color: grey;
  }

  .chatbox-wrapper {
    position: absolute;
    background: white;
    width: 93%;
    display: flex;
    justify-content: center;
    bottom: 0;
    align-items: center;
    left: 0;
  }

  .chatbox {
    width: 100%;
    margin: 1em;
  }
}
</style>
