import axios from 'axios'
import configuration from '../../configuration.json'
import { getBearerToken } from './tokenHandler'

const axiosInstance = axios.create({
  baseURL: configuration.baseUrl,
  headers: {
    'Content-Type': 'application/json'
  }
})

axiosInstance.interceptors.request.use(
  config => {
    const bearerToken = getBearerToken()

    config.headers.Authorization = bearerToken

    return config
  }
)

export default axiosInstance
