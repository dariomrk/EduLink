import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { DateInput } from '@mantine/dates'
import { TextInput, Flex, PasswordInput, Button } from '@mantine/core'
import { ReactComponent as Calender } from '../../img/calender.svg'
import PageTitle from '../../components/PageTitle'
import { tryRegister } from '../../services/apiService'

export const RegisterPage = () => {
  const [activeStep, setActiveStep] = useState(0)
  const [name, setName] = useState('')
  const [city, setCity] = useState('')
  const [birthDate, setBirthDate] = useState('')
  const [username, setUsername] = useState('')
  const [email, setEmail] = useState('')
  const [password, setPassword] = useState('')

  async function onSubmit (event) {
    if (name && city && birthDate && username && email && password) {
      const obj = {
        email,
        username,
        password,
        firstName: name,
        lastName: name,
        dateOfBirth: birthDate.toISOString().split('T')[0],
        cityName: city,
        regionName: 'Splitsko-Dalmatinska',
        countryName: 'Hrvatska',
        mobileNumber: '0000000000'
      }
      const responce = await tryRegister(obj)
    }
  }
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
          label="Ime i prezime"
          value={name}
          onChange={event => setName(event.currentTarget.value)}
        />
        <DateInput
          icon={<Calender />}
          valueFormat="YYYY MMM DD"
          value={birthDate}
          onChange={setBirthDate}
          label="Date input"
          placeholder="Date input"
        />

        <TextInput
          label="Grad"
          value={city}
          onChange={event => setCity(event.currentTarget.value)}
        />
        <Button onClick={() => setActiveStep(activeStep + 1)}>Dalje</Button>
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
          <Button onClick={() => setActiveStep(activeStep - 1)} width="50%">
            Natrag
          </Button>
          <Button onClick={() => onSubmit()} width="50%">
            Dalje
          </Button>
        </Flex>
      </Flex>
    )
  }

  return (
    <>
      <PageTitle p="84px 10px" title="Registracija" />
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
              textAlign: 'center'
            }}
          >
            Imaš račun?
            <Link to="/login" style={{ textDecoration: 'underline' }}>
              Prijavi se
            </Link>
          </p>
        </Flex>
      </div>
    </>
  )
}
