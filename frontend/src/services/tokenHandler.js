
const localStorageKeys = Object.freeze({
  bearerToken: 'bearer-token'
})

export const getBearerToken = () => localStorage.getItem(localStorageKeys.bearerToken)
export const setBearerToken = (token) => localStorage.setItem(localStorageKeys.bearerToken, token)
