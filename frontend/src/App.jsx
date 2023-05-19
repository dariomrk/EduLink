import React from 'react'
import './index.css'
import { MantineProvider } from '@mantine/core'
import Router from './router'
import { Colors } from './style/colors'

function App () {
  return (
    <MantineProvider
      theme={{
        components: {
          Button: {
            styles: (theme, params, { variant }) => ({
              root: {
                width: '100%',
                height: 'auto',
                fontSize: '16px',
                fontWeight: 700,
                padding: '16px 0',
                overflowWrap: 'break-word',
                background:
                  variant === 'filled'
                    ? 'linear-gradient(87.91deg, #9E3DFF 3.54%, #D2A6FF 239.42%)'
                    : '#FFFFFF',
                color: variant === 'filled' ? 'white' : Colors.Background,
                borderColor: variant === 'filled' ? 'white' : Colors.Text,
                '&:hover': {
                  backgroundColor: '#E4E4E4'
                }
              }
            })
          },
          Checkbox: {
            styles: () => ({
              root: {
                border: '1px solid #E4E4E4',
                boxSizing: 'border-box',
                padding: '15px',
                width: '100%',
                borderRadius: '10px',
                fontSize: '16px',
                fontWeight: '700',
                color: Colors.Title
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
