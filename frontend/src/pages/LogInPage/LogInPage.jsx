import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { TextInput, Flex, PasswordInput, Button } from '@mantine/core'
import { PageTitle } from '../../components/PageTitle/PageTitle'

export const LogInPage = () => {
  const [username, setUsername] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  console.log(username, email)
  return (
    <>
      <PageTitle p="84px 10px" title="Prijava" />
      <Flex
        direction="column"
        gap="24px"
        style={{ boxSizing: 'border-box' }}
        m="auto"
        p="40px"
        stayle={{ gap: '24px' }}
        w={{ base: '330px', sm: '450px', md: '600px', lg: '750px ' }}
      >
        <TextInput
          label="Email/Korisnično ime"
          value={username || email}
          onChange={event =>
            event.currentTarget.value.includes('@')
              ? (setEmail(event.currentTarget.value), setUsername(''))
              : (setUsername(event.currentTarget.value), setEmail(''))
          }
        />
        <PasswordInput
          value={password}
          label="Lozinka"
          onChange={event => setPassword(event.currentTarget.value)}
        />
        <Link
          to="/help"
          style={{
            textDecoration: 'underline',
            textAlign: 'right'
          }}
        >
          Ne sjećaš se lozinke?
        </Link>
        <Button
          // onClick={() => }
          width="100%"
        >
          Prijavi se
        </Button>{' '}
        <p
          style={{
            textAlign: 'center'
          }}
        >
          Imaš račun?
          <Link to="/register" style={{ textDecoration: 'underline' }}>
            Registriraj se
          </Link>
        </p>
      </Flex>
    </>
  )
}
