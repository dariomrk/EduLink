import { Button } from '@mantine/core'
import React from 'react'
import { Link } from 'react-router-dom'

export const CustomButton = props => {
  return (
    <Link to={props.link} style={{ width: '100%' }}>
      <Button
        variant={props.variant}
        style={{
          width: props.width,
          height: 'auto',
          fontSize: '16px',
          fontWeight: 700,
          padding: '16px 0',
          overflowWrap: 'break-word'
        }}
        radius="10px"
      >
        {props.text}
      </Button>
    </Link>
  )
}
