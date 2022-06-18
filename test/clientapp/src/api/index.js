import instance from './instance'

import weatherforecast from './weatherforecast'

export default {
    weatherforecast: weatherforecast(instance)
}