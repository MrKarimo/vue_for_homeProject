<template>
    <div>
        <div>Date: {{info.date}},</div> 
        <div>TemperatureC: {{info.temperatureC}},</div> 
        <div>TemperatureF: {{info.temperatureF}},</div> 
        <div>Summary: {{info.summary}};</div> 
    </div>
</template>

<script>
    export default {
        name: 'Plate',
        props: {
            info: {
                type: Object,
                default() {
                    return {
                        date: new Date(),
                        temperatureC: 0,
                        temperatureF: 0,
                        summary: '',
                    }
                }
            }
        },
    }
</script>