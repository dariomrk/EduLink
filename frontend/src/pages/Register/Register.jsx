import React from 'react'
import { useForm } from '@mantine/form'
import { tryRegister } from '../../services/apiHandler'
import { TextInput, Title, Text, Select, Card, Button, PasswordInput } from '@mantine/core'
import { DateInput } from '@mantine/dates'

function Register () {
  const form = useForm({
    initialValues: {
      email: '',
      username: '', // split to first name & last name
      name: '',
      password: '',
      dateOfBirth: '', // yyyy-dd-mm
      location: '', // split to city, region & country
      mobileNumber: ''
    }
  })

  const submitHandler = async (formData) => {
    const requestData = {
      ...formData,
      // this does not cover the case when someone has a middle name
      dateOfBirth: formData.dateOfBirth.toString(),
      firstName: formData.name.split(' ')[0].trim(),
      lastName: formData.name.split(' ')[1].trim(),
      city: formData.location.split(',')[0].trim(),
      region: formData.location.split(',')[1].trim(),
      country: formData.location.split(',')[2].trim()
    }

    console.log(requestData)

    const registrationResult = await tryRegister(requestData)

    console.log(registrationResult)
  }

  return (
  <form onSubmit={form.onSubmit(submitHandler)}>
    <Card>
      <Title>Registriraj se</Title>
      <Text mt={'md'}>Ime i prezime</Text>
      <TextInput {...form.getInputProps('name')}></TextInput>

      <Text mt={'md'}>Datum rođenja</Text>
      <DateInput {...form.getInputProps('dateOfBirth')}></DateInput>

      <Text mt={'md'}>Grad</Text>
      <Select
        data={['Split, Splitsko-dalmatinska, Hrvatska']} // get data from api
        {...form.getInputProps('location')}
      ></Select>

      <Text mt={'md'}>Korisničko ime</Text>
      <TextInput {...form.getInputProps('username')}></TextInput>

      <Text mt={'md'}>Email</Text>
      <TextInput {...form.getInputProps('email')}></TextInput>

      <Text mt={'md'}>Lozinka</Text>
      <PasswordInput {...form.getInputProps('password')}></PasswordInput>

      <Text>Broj mobitela</Text>
      <TextInput {...form.getInputProps('mobileNumber')}></TextInput>
      <Button type='submit' fullWidth mt={'md'}>Dalje</Button>
    </Card>
  </form>)
}

export default Register
