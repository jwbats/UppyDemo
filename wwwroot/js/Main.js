import Main from '../vue/Main.vue';

addEventListener('load', (event) => {
	var appMain = Vue.createApp(Main);
	appMain.mount('#main');
});