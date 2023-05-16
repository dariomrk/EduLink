import { Box, Badge } from '@mantine/core'
import React from 'react'

export const Tag = (props) => {
  return (
    <Box>
        <Badge style={{
          padding: '8px 11px',
          color: '#8D8BA7',
          backgroundColor: '#F1EFFE',
          textTransform: 'none',
          fontSize: '12px',
          borderRadius: '6px',
          fontWeight: 400,
          height: 'auto'
        }} variant="filled" fullWidth>{props.tag}</Badge>
      </Box>
  )
}
