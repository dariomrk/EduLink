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

export const getAllMessages = async (paginationOptions, sortOptions) => {
  try {
    const response = await api.get('messages', {
      params: {
        paginationOptions,
        sortOptions
      }
    })
    return response.data
  } catch (error) {
    throw new Error('Failed to get messages.')
  }
}

export const createMessage = async createRequest => {
  try {
    const response = await api.post('messages', createRequest)
    return response.data
  } catch (error) {
    throw new Error('Failed to create message.')
  }
}
