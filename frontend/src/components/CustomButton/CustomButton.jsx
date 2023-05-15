import { Button } from '@mantine/core'
import React from 'react'

export const CustomButton = (props) => {
  return (
        <Button
          color="purple"
          variant={props.variant}
          style={{
            maxWidth: '100%',
            height: 'auto',
            fontSize: '16px',
            fontWeight: 700,
            padding: '16px 0',
            width: '320px',
            overflowWrap: 'break-word'
          }} radius="10px">
            {props.text}
        </Button>
  )
}
