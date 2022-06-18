<template>
    <div class="foofer">
        <ul>
            <li>
                <router-link to="/" exact>Home</router-link>
            </li>
            <li>
                <router-link to="/Weather">Погода</router-link>
            </li>
            <li>
                <router-link to="/institutionApplication">Институты</router-link>
            </li>
        </ul>
    </div>
</template>

<script>
    export default {
        name: 'Lyout'

    }
</script>

<style>
    ul{
        margin:auto;
        padding:0px;
    }

    li {
        list-style-type: none;
        display: inline;
        padding: 10px 15px;
    }

    a{
        text-decoration: none;
        color: black;
    }

    .foofer {
        height: 80px;
        display: grid;
        justify-content: start;
        align-content: center;
    }
</style>