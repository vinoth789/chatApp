import { reactive, toRefs } from 'vue';

const state = reactive({
  error: null,
  currentUser: {},
  users: [],
  messages: []
});

const url = `${import.meta.env.VITE_APP_API_URL}/api`;


export default function () {
  const setUser = async (userId) => {
    console.log("userId ** ", userId);
    try {
      const currentUserData = await fetch(url+`/users/${userId}`).then((res) => res.json());
      console.log("userId helloooo ", currentUserData);
      state.currentUser = currentUserData;
      sessionStorage.setItem('user', JSON.stringify(state.currentUser));
      getUsers();
      getMessages();
    } catch (err) {
      state.error = err;
    }
  };

  const getUsers = async () => {
    try {
      const userData = await fetch(url+`/users`).then((res) => res.json());
      console.log("users list ", userData);
      state.users = userData;
    } catch (err) {
      state.error = err;
    }
  };

  const createUser = async (userData) => {
    console.log("I am inside", userData);
    try {    
    const response = await fetch(url+`/users/register`, {
      method: 'POST',
      headers: {'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*'},
      body: JSON.stringify(userData)
    });

  } catch (err) {
    state.error = err;
  }
};

  const getMessages = async () => {
    try {
      const messageData = await fetch(url+`/chats`).then((res) => res.json());
      console.log("message list ", messageData);
      state.messages = messageData;
    } catch (err) {
      state.error = err;
    }
  };

  const sendMessage = async (chatData) => {
    console.log("I am inside", chatData);
    try {
        const response = await fetch(url+`/chats/register`, {
          method: 'POST',
          headers: {'Content-Type': 'application/json', 'Access-Control-Allow-Origin': '*'},
          body: JSON.stringify(chatData)
      });
      getMessages();
    } catch (err) {
      state.error = err;
    }
  };


  return {
    // States
    ...toRefs(state),

    // Actions
    getMessages,
    getUsers,
    createUser,
    setUser,
    sendMessage
  };
}
