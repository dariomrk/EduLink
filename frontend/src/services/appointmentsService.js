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

export const getAllAppointments = async (sortOptions, paginationOptions) => {
  try {
    const response = await api.get('appointments', {
      params: {
        sortOptions,
        paginationOptions
      }
    })
    return response.data
  } catch (error) {
    throw new Error('Failed to get appointments.')
  }
}

export const getAllFutureAppointments = async (
  sortOptions,
  paginationOptions
) => {
  try {
    const response = await api.get('appointments/future', {
      params: {
        sortOptions,
        paginationOptions
      }
    })
    return response.data
  } catch (error) {
    throw new Error('Failed to get future appointments.')
  }
}

export const getAppointment = async id => {
  try {
    const response = await api.get(`appointments/${id}`)
    return response.data
  } catch (error) {
    throw new Error('Failed to get appointment.')
  }
}

export const createAppointment = async createRequest => {
  try {
    const response = await api.post('appointments', createRequest)
    return response.data
  } catch (error) {
    throw new Error('Failed to create appointment.')
  }
}

export const cancelAppointment = async id => {
  try {
    const response = await api.patch(`appointments/${id}/cancel`)
    return response.data
  } catch (error) {
    throw new Error('Failed to cancel appointment.')
  }
}

export const reviewAppointmentAsStudent = async (id, reviewRequest) => {
  try {
    const response = await api.post(
      `appointments/${id}/review/student`,
      reviewRequest
    )
    return response.data
  } catch (error) {
    throw new Error('Failed to review appointment as student.')
  }
}

export const reviewAppointmentAsTutor = async (id, reviewRequest) => {
  try {
    const response = await api.post(
      `appointments/${id}/review/tutor`,
      reviewRequest
    )
    return response.data
  } catch (error) {
    throw new Error('Failed to review appointment as tutor.')
  }
}
