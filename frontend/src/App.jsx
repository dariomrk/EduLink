import React from 'react'
import './index.css'
import { MantineProvider } from '@mantine/core'
import { Color } from './style/colors.js'
import CustomButton from './components/CustomButton/index.js'

function App() {
  return (
    <MantineProvider
      theme={{
        colors: {
          'purple': [Color.Primary + "", Color.Secondary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary], //more shades
        },
      }}
    >
      <CustomButton value="Vrati me na početnu" variant="filled" link="/" />
    </MantineProvider>
  )
}

export default App
