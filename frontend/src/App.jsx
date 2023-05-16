import React from 'react'
import './index.css'
import { MantineProvider } from '@mantine/core'
import { Color } from './style/colors.js'

function App () {
  return (
    <MantineProvider
      theme={{
        colors: {
          purple: [
            Color.Primary,
            Color.Secondary,
            Color.Primary,
            Color.Primary,
            Color.Primary,
            Color.Primary,
            Color.Primary,
            Color.Primary,
            Color.Primary,
            Color.Primary
          ] // more shades
        }
      }}
    ></MantineProvider>
  )
}

export default App
