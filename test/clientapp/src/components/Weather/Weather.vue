<template>
    <div>
        <dev>
            <button @click="getwether_fetch()">fetch</button>
            <button @click="getwether_axios()">axios</button>
            <button @click="erese()">Сбросить</button>
        </dev>
        <Plate v-for="(item, index) in arr" :key="index" :info="item"></Plate>
        <button>
            <router-link to="/" exact>Home</router-link>
        </button>

    </div>
</template>

<script>
    import Plate from './Plate.vue'

    export default {
        name: 'Weather',
        components: {
            Plate,
        },
        data() {
            return {
                arr: [],
            }
        },
        mounted() {
             this.getwether_fetch();
        },
        methods: {
            async getwether_fetch() {
                let res = await fetch('http://localhost:50598/weatherforecast');
                if (res.ok) {
                    this.arr = await res.json();
                }
            },
            getwether_axios() {
                this.$load(async () => {
                    this.arr = (await this.$api.weatherforecast.get_weatherforecast()).data;
                });
            },
            erese() {
                this.arr = [];
            },
        }

        
    }
</script>