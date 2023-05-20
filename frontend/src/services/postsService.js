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

export const getAllPostsFromCountry = async (
  countryName,
  sortOptions,
  paginationOptions
) => {
  try {
    const response = await api.get(`posts/country/${countryName}`, {
      params: {
        sortOptions,
        paginationOptions
      }
    })
    return response.data
  } catch (error) {
    throw new Error('Failed to get posts from country.')
  }
}

export const getAllPostsFromRegion = async (
  countryName,
  regionName,
  sortOptions,
  paginationOptions
) => {
  try {
    const response = await api.get(
      `posts/region/${countryName}/${regionName}`,
      {
        params: {
          sortOptions,
          paginationOptions
        }
      }
    )
    return response.data
  } catch (error) {
    throw new Error('Failed to get posts from region.')
  }
}

export const getAllPostsFromSubject = async (
  countryName,
  regionName,
  subjectName,
  sortOptions,
  paginationOptions
) => {
  try {
    const response = await api.get(
      `posts/subject/${countryName}/${regionName}/${subjectName}`,
      {
        params: {
          sortOptions,
          paginationOptions
        }
      }
    )
    return response.data
  } catch (error) {
    throw new Error('Failed to get posts from subject.')
  }
}

export const getPost = async id => {
  try {
    const response = await api.get(`posts/${id}`)
    return response.data
  } catch (error) {
    throw new Error('Failed to get post.')
  }
}

export const createPost = async postRequest => {
  try {
    const response = await api.post('posts/create', postRequest)
    return response.data
  } catch (error) {
    throw new Error('Failed to create post.')
  }
}
