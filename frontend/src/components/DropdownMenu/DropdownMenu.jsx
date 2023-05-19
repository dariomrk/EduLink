import React from 'react'
import { ReactComponent as MenuIcon } from '../../img/header/menu.svg'
import { Menu, UnstyledButton } from '@mantine/core'
import { Link } from 'react-router-dom'

export const DropdownMenu = () => {
  const handleClick = () => {
    console.log('Odjava') // TODO: make actual log in
  }
  return (
    <Menu>
      <Menu.Target>
        <UnstyledButton>
          <MenuIcon />
        </UnstyledButton>
      </Menu.Target>

      <Menu.Dropdown>
        <Link to="/login">
          <Menu.Item>Prijavi se</Menu.Item>
        </Link>
        <Link to="/register">
          <Menu.Item>Registriraj se</Menu.Item>
        </Link>
        <Link to="/">
          <Menu.Item
            onClick={() => {
              handleClick()
            }}
          >
            Odjava
          </Menu.Item>
        </Link>
      </Menu.Dropdown>
    </Menu>
  )
}
