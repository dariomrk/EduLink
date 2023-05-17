import React from 'react'
import './index.css'
import { MantineProvider } from '@mantine/core'
import { Color } from './style/colors.js'

function App () {
  return (
    <MantineProvider
      theme={{
        fontFamily: 'DM Sans',
        colors: {
          purple: [
            Color.Primary,
            Color.Secondary,
            Color.Primary
          ]
        }
      }}
    ></MantineProvider>
  )
}

export default App
