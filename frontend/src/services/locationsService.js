import axios from 'axios'
import config from '../../config.json'
import { getBearerToken } from './tokenService'

const api = axios.create({
  baseURL: config.api.baseUrl,
  headers: {
    'Content-Type': 'application/json'
  }
})

api.interceptors.request.use(config => {
  const bearerToken = getBearerToken()

  if (bearerToken) {
    config.headers.Authorization = `Bearer ${bearerToken}`
  }

  return config
})

export const getAllLocationsFromCountry = async country => {
  try {
    const response = await api.get(`locations/country/${country}`)
    return response.data
  } catch (error) {
    throw new Error('Failed to get locations from country.')
  }
}
