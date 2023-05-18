import { useDisclosure } from '@mantine/hooks'
import {
  Button,
  Group,
  Drawer,
  MultiSelect,
  Select,
  Container
} from '@mantine/core'
import React from 'react'
import CustomButton from '../CustomButton'

export const Filter = () => {
  const [opened, { open, close }] = useDisclosure(false)

  return (
    <>
      <Drawer opened={opened} onClose={close} position="bottom" size="md">
        <Container w={{ base: '90%' }} mt="10px">
          <h1>Title</h1>
          <MultiSelect
            data={[]} // dodaj data
            label="Teme"
            placeholder="Teme"
            searchable
            nothingFound="Nismo ništa pronašli"
            mb="16px"
          />

          <Select
            data={['Jutarnji termini', 'Popodnevni termini', 'Kroz cijeli dan']}
            label="Dostupnost"
            placeholder="Dostupnost"
            searchable
            nothingFound="Nismo ništa pronašli"
            mb="16px"
          />

          <CustomButton text="Primjeni filtere" link="" width="100%" />
        </Container>
      </Drawer>

      <Group position="center">
        <Button onClick={open} h="36px" variant="outline" color="black" ml="10px">
          Filteri
        </Button>
      </Group>
    </>
  )
}
