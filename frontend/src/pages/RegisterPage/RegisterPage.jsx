import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { DateInput } from '@mantine/dates'
import { TextInput, Flex, PasswordInput } from '@mantine/core'
import CustomButton from '../../components/CustomButton'
import { Color } from '../../style/colors'
import { ReactComponent as Calender } from '../../img/calender.svg'

export const RegisterPage = () => {
  const [activeStep, setActiveStep] = useState(0)
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [birthDate, setBirthDate] = useState('')
  const [username, setUsername] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  const firstStep = () => {
    return (
      <Flex
        direction="column"
        gap="24px"
        style={{ boxSizing: 'border-box' }}
        m="auto"
        p="0"
        stayle={{ gap: '24px' }}
        w="100%"
      >
        <TextInput
          label="Ime"
          value={firstName}
          onChange={event => setFirstName(event.currentTarget.value)}
        />
        <TextInput
          label="Prezime"
          value={lastName}
          onChange={event => setLastName(event.currentTarget.value)}
        />
        <DateInput
          icon={<Calender />}
          valueFormat="YYYY MMM DD"
          value={birthDate}
          onChange={setBirthDate}
          label="Date input"
          placeholder="Date input"
        />
        <CustomButton
          text="Dalje"
          onClick={() => setActiveStep(activeStep + 1)}
        />
      </Flex>
    )
  }

  const secondStep = () => {
    return (
      <Flex
        direction="column"
        gap="24px"
        style={{ boxSizing: 'border-box' }}
        m="auto"
        p="0"
        stayle={{ gap: '24px' }}
        w="100%"
      >
        <TextInput
          label="Korisnično ime"
          value={username}
          onChange={event => setUsername(event.currentTarget.value)}
        />
        <TextInput
          label="Email"
          value={email}
          onChange={event => setEmail(event.currentTarget.value)}
        />

        <PasswordInput
          value={password}
          label="Lozinka"
          onChange={event => setPassword(event.currentTarget.value)}
        />

        <Flex
          direction="row"
          gap="24px"
          style={{ boxSizing: 'border-box' }}
          m="auto"
          p="0"
          stayle={{ gap: '24px' }}
          w="100%"
        >
          <CustomButton
            text="Natrag"
            onClick={() => setActiveStep(activeStep - 1)}
            width="50%"
          />
          <CustomButton
            text="Dalje"
            onClick={() => setActiveStep(activeStep + 1)}
            width="50%"
          />
        </Flex>
      </Flex>
    )
  }

  return (
    <div>
      <Flex // TODO: Change colors for input outline and labels
        direction="column"
        gap="24px"
        style={{ boxSizing: 'border-box' }}
        m="auto"
        p="40px"
        stayle={{ gap: '24px' }}
        w={{ base: '330px', sm: '450px', md: '600px', lg: '750px ' }}
      >
        {activeStep === 0 ? firstStep() : secondStep()}

        <p
          style={{
            textAlign: 'center',
            color: Color.Button
          }}
        >
          Imaš račun?
          <Link to="/login" style={{ textDecoration: 'underline' }}>
            Prijavi se
          </Link>
        </p>
      </Flex>
    </div>
  )
}
