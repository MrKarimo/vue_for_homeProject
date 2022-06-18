export default {
    install(Vue) {
        Vue.prototype.$load = async (action, errHandler) => {
            try {
                await action();
            }
            catch (error) {
                if (errHandler) {
                    errHandler();
                }
                else {
                    alert(error.response.data);
                }
            }
        }
    }
}