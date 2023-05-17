import React from 'react'
import { Flex } from '@mantine/core'
import { ReactComponent as Logo } from '../../img/logo.svg'

export const Header = () => {
  return (
    <Flex
      p="15px 24px"
      style={{ width: '100 %' }}
      align="center"
      justify="center"
    >
      <Logo />
    </Flex>
  )
}
