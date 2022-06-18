<template>
    <div id="app">
        <Lyout />
        <router-view />
    </div>
</template>

<script>
    import Lyout from "./components/Lyout"

    export default {
        name: 'app',
        components: {
            Lyout
        }
    }
</script>

<style>
</style>
