import React, { useEffect, useState } from 'react'
import { Select } from '@mantine/core'
import { useNavigate, useLocation } from 'react-router-dom'

export const Sort = () => {
  const location = useLocation()
  const [params, setParams] = useState()
  const navigate = useNavigate()

  useEffect(() => {
    if (params) {
      navigate(location.pathname + '?search=' + params)
    } else {
      navigate(location.pathname)
    }
  }, [params])

  return (
    <Select
      w="150px"
      onChange={e => setParams(e)}
      placeholder="Sortiraj prema"
      data={[
        { value: '', label: 'Prikaži sve' },
        { value: 'name', label: 'Imenima (A-Ž)' },
        { value: 'price', label: 'Najnižoj cijeni' },
        { value: 'distance', label: 'Blizini' },
        { value: 'rate', label: 'Najboljim ocjenama' }
      ]}
    />
  )
}
