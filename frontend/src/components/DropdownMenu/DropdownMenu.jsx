import React, { useState } from 'react'
import { ReactComponent as MenuIcon } from '../../img/header/menu.svg'
import { Menu, UnstyledButton } from '@mantine/core'
import { Link } from 'react-router-dom'
import { getBearerToken } from '../../services/tokenService'

export const DropdownMenu = () => {
  const [user, setUser] = useState(getBearerToken())
  const handleClick = () => {
    localStorage.removeItem('bearer-token')
    setUser(null)
  }
  return (
    <Menu>
      <Menu.Target>
        <UnstyledButton>
          <MenuIcon />
        </UnstyledButton>
      </Menu.Target>

      {user
        ? (
        <Menu.Dropdown>
          {' '}
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
          )
        : (
        <Menu.Dropdown>
          <Link to="/login">
            <Menu.Item>Prijavi se</Menu.Item>
          </Link>
          <Link to="/register">
            <Menu.Item>Registriraj se</Menu.Item>
          </Link>
        </Menu.Dropdown>
          )}
    </Menu>
  )
}
