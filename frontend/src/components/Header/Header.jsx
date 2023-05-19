import React from 'react'
import { Flex } from '@mantine/core'
import { ReactComponent as Logo } from '../../img/logo.svg'
export const Header = () => {
  return (
    <Flex
      p="15px 24px"
      style={{
        width: '100 %',
        borderBottom: '1px solid #E0E0E0',
        position: 'sticky',
        top: '0',
        zIndex: '1',
        backgroundColor: 'white',
        left: '0',
        right: '0'
      }}
      align="center"
      justify="space-between"
    >
      <div style={{ width: '100px' }} />
      <Logo />

      <div
        style={{
          width: '100px',
          overflowWrap: 'break-word',
          display: 'flex',
          justifyContent: 'flex-end'
        }}
      ></div>
    </Flex>
  )
}
