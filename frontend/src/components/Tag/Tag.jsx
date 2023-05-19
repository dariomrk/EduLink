import { Box, Badge } from '@mantine/core'
import React from 'react'

export const Tag = props => {
  return (
    <Box>
      <Badge
        style={{
          padding: '8px 11px',
          color: '#8D8BA7',
          backgroundColor: 'white',
          border: '1px solid #8D8BA7',
          textTransform: 'none',
          fontSize: '12px',
          borderRadius: '6px',
          fontWeight: 400,
          height: 'auto'
        }}
        variant="filled"
        fullWidth
      >
        {props.tag}
      </Badge>
    </Box>
  )
}
