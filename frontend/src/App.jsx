import React from 'react'
import './index.css'
import { MantineProvider } from '@mantine/core'
import { Color } from './style/colors.js'
import Router from './router'

function App () {
  return (
    <MantineProvider
      theme={{
        colors: {
          purple: [
            '-',
            '-',
            '-',
            '-',
            '-',
            '-',
            Color.Button, // font and outline, fill
            Color.Primary, // hover of filled button
            '-',
            '-'
          ]
        },
        primaryColor: 'purple'
      }}
    >
      <Router />
    </MantineProvider>
  )
}

export default App
