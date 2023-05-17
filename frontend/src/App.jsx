import React from 'react'
import './index.css'
import { MantineProvider } from '@mantine/core'
import Router from './router'
import { Color } from './style/colors'

function App () {
  return (
    <MantineProvider
      theme={{
        components: {
          Button: {
            styles: (theme, params, { variant }) => ({
              root: {
                height: '2.625rem',
                padding: '0 1.875rem',
                backgroundColor: variant === 'filled' ? Color.Button : 'white',
                color: variant === 'filled' ? 'white' : Color.Button,
                border: `1px solid ${Color.Button}`,
                '&:hover': {
                  backgroundColor:
                    variant === 'filled' ? Color.Primary : Color.Secondary
                }
              }
            })
          },
          breakpoints: {
            sm: '25em',
            md: '45em',
            lg: '65em'
          }
        }
      }}
    >
      <Router />
    </MantineProvider>
  )
}

export default App
