import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { TextInput, Flex, PasswordInput } from '@mantine/core'
import CustomButton from '../../components/CustomButton'
import { Color } from '../../style/colors'
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
            textAlign: 'right',
            color: Color.Button
          }}
        >
          Ne sjećaš se lozinke?
        </Link>

        <CustomButton
          text="Prijavi se"
          // onClick={() => }
          width="100%"
        />
        <p
          style={{
            textAlign: 'center',
            color: Color.Button
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
