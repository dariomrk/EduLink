import axios, { HttpStatusCode } from 'axios'
import config from '../../config.json'
import { getBearerToken, setBearerToken } from './tokenService'

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

export const tryRegister = async userData => {
  try {
    const response = await api.post('identity/register', userData)

    if (response.status === HttpStatusCode.Ok) {
      setBearerToken(response.data.bearerToken)
      return true
    }
    return false
  } catch (error) {
    console.error(error)
    return false
  }
}

export const tryLogin = async userData => {
  try {
    const response = await api.post('identity/login', userData)

    if (response.status === HttpStatusCode.Ok) {
      setBearerToken(response.data.bearerToken)
      return true
    }
    return false
  } catch (error) {
    console.error(error)
    return false
  }
}
