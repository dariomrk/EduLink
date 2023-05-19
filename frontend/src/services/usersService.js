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

export const getAllTutorsInRegion = async (
  countryName,
  regionName,
  sortOptions,
  paginationOptions
) => {
  try {
    const response = await api.get(
      `users/tutors/region/${countryName}/${regionName}`,
      {
        params: {
          sortOptions,
          paginationOptions
        }
      }
    )
    return response.data
  } catch (error) {
    throw new Error('Failed to get tutors in region.')
  }
}

export const getAllTutorsInCity = async (
  countryName,
  regionName,
  cityName,
  sortOptions,
  paginationOptions
) => {
  try {
    const response = await api.get(
      `users/tutors/city/${countryName}/${regionName}/${cityName}`,
      {
        params: {
          sortOptions,
          paginationOptions
        }
      }
    )
    return response.data
  } catch (error) {
    throw new Error('Failed to get tutors in city.')
  }
}

export const getAllStudents = async (sortOptions, paginationOptions) => {
  try {
    const response = await api.get('users/students', {
      params: {
        sortOptions,
        paginationOptions
      }
    })
    return response.data
  } catch (error) {
    throw new Error('Failed to get students.')
  }
}
