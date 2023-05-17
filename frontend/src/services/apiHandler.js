import { HttpStatusCode } from 'axios'
import axiosInstance from './axiosInstance'
import { setBearerToken } from './tokenHandler'

export const tryRegister = async (data) => {
  const response = await axiosInstance.post('identity/register', data)

  if (response.status === HttpStatusCode.Ok) {
    setBearerToken(response.data.bearerToken)
    return true
  }
  return false
}

export const tryLogin = async (data) => {
  const response = await axiosInstance.post('identity/login', data)
  if (response.status === HttpStatusCode.Ok) {
    setBearerToken(response.data.bearerToken)
    return true
  }
  return false
}
