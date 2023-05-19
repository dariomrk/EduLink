import React from 'react'

export const PageTitle = props => {
  return (
    <div
      style={{
        background:
          'linear-gradient(87.91deg, #273043 3.54%, rgba(0, 69, 215, 0.55) 239.42%)',
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
