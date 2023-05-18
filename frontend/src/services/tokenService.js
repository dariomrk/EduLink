const bearerTokenLocalstorageKey = 'bearer-token'

export const getBearerToken = () => localStorage.getItem(bearerTokenLocalstorageKey)
export const setBearerToken = (token) => localStorage.setItem(bearerTokenLocalstorageKey, token)
