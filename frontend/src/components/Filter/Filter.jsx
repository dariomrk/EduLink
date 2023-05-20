import { useDisclosure } from '@mantine/hooks'
import { Button, Group, Drawer, Select, Container } from '@mantine/core'
import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom'
import { getAllFieldsFromSubject } from '../../services/subjectsServices'

export const Filter = () => {
  const { categoryName } = useParams()
  const [opened, { open, close }] = useDisclosure(false)
  const [tags, setTags] = useState([])
  const [tag, setTag] = useState()
  const [time, setTime] = useState()

  function handleClick () {
    console.log(tag, time)
  }

  useEffect(() => {
    ;(async () => {
      try {
        const result = await getAllFieldsFromSubject(categoryName)
        setTags(result.fields)
      } catch (err) {
        console.log(err)
      }
    })()
    console.log(tags)
  }, [])

  return (
    <>
      <Drawer opened={opened} onClose={close} position="bottom" size="md">
        <Container w={{ base: '90%' }} mt="10px">
          <h1>Title</h1>
          <Select
            onChange={setTag}
            data={tags}
            label="Teme"
            placeholder="Teme"
            searchable
            nothingFound="Nismo ništa pronašli"
            mb="16px"
          />

          <Select
            onChange={setTime}
            data={['Jutarnji termini', 'Popodnevni termini', 'Kroz cijeli dan']}
            label="Dostupnost"
            placeholder="Dostupnost"
            searchable
            nothingFound="Nismo ništa pronašli"
            mb="16px"
          />

          <Button onClick={() => handleClick()}> Primjeni filtere</Button>
        </Container>
      </Drawer>

      <Group position="center">
        <Button
          p="10px"
          onClick={open}
          variant="outline"
          color="black"
          ml="10px"
        >
          Filteri
        </Button>
      </Group>
    </>
  )
}
