import { Button } from '@mantine/core'
import React from 'react'
import { Link } from 'react-router-dom'

export const CustomButton = props => {
  return (
    <Link to={props.link} style={{ width: props.width }}>
      <Button
        onClick={
          props.disable
            ? event => event.preventDefault()
            : () => props.onClick()
        }
        data-disabled={props.disable ? true : null}
        sx={
          props.disable
            ? { '&[data-disabled]': { pointerEvents: 'all' } }
            : null
        }
        variant={props.variant}
        style={{
          width: '100%',
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
