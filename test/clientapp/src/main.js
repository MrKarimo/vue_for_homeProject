import Vue from 'vue'
import App from './App.vue'
import routes from './route'

import VueRouter from "vue-router";
import ApiPlagin from './plugins/api'
import LoadPlagin from './plugins/load'

Vue.use(VueRouter);
Vue.use(ApiPlagin);
Vue.use(LoadPlagin);

const router = new VueRouter({
    routes,
    mode: "history",
});

Vue.config.productionTip = false

new Vue({
    router,
    render: h => h(App),
}).$mount('#app')
