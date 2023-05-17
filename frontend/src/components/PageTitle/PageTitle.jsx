import React from 'react'
import { Color } from '../../style/colors'

export const PageTitle = props => {
  return (
    <div
      style={{
        backgroundColor: Color.Primary,
        color: 'white',
        textAlign: 'center',
        padding: props.p,
        width: '100%',
        boxSizing: 'border-box'
      }}
    >
      <div
        style={{
          fontSize: '32px',
          fontWeight: 700,
          lineHeight: '40px',
          marginBottom: '24px'
        }}
      >
        {props.title}
      </div>

      <div
        style={{
          fontSize: '14px',
          fontWeight: 400,
          lineHeight: '24px',
          maxWidth: '800px',
          margin: 'auto'
        }}
      >
        {props.subtitle}
      </div>
    </div>
  )
}
