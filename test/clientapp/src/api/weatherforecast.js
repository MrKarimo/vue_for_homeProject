export default function (instance) {
    return {
        get_weatherforecast() {
            return instance.get('weatherforecast');
        },
    }
}