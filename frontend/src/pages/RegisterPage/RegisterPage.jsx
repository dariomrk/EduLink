import React, { useState } from 'react'
import { Link } from 'react-router-dom'
import { DateInput } from '@mantine/dates'
import { TextInput, Flex } from '@mantine/core'
import CustomButton from '../../components/CustomButton'
import { Color } from '../../style/colors'
import { ReactComponent as Calender } from '../../img/calender.svg'

export const RegisterPage = () => {
  const [firstName, setFirstName] = useState('')
  const [lastName, setLastName] = useState('')
  const [birthDate, setBirthDate] = useState('')
  console.log(`${firstName}, ${lastName}, ${birthDate}`)
  return (
    // TODO: Change colors for input outline and labels
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
      <CustomButton text="Dalje" />

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
  )
}
