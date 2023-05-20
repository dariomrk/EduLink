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

export const getAllFieldsFromSubject = async subjectName => {
  try {
    const response = await api.get(`subjects/${subjectName}`)
    return response.data
  } catch (error) {
    console.log(error)
    throw new Error('Failed to get fields from subject.')
  }
}

export const getAllSubjects = async () => {
  try {
    const response = await api.get('subjects')
    return response.data
  } catch (error) {
    throw new Error('Failed to get all subjects.')
  }
}
