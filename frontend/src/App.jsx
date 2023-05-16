import React from 'react'
import './index.css'
import { MantineProvider } from '@mantine/core'
import { Color } from './style/colors.js'
import { InstructorCard } from './components/InstructorCard/InstructorCard.jsx'
function App () {
  return (
    <MantineProvider
      theme={{
        colors: {
          purple: [Color.Primary, Color.Secondary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary, Color.Primary] // more shades
        }
      }}
    >
      <InstructorCard name="Nikola" stars="4.5" review="5" distance="1.2 km" />
    </MantineProvider>
  )
}

export default App
