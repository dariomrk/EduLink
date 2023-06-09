import React from 'react'
import { ReactComponent as Wrong } from '../../img/wrong.svg'
import { Flex, Button } from '@mantine/core'
import { Link } from 'react-router-dom'

export const NotFoundPage = () => {
  return (
    <Flex
      gap="16px"
      justify="center"
      align="center"
      direction="column"
      wrap="wrap"
      p="30px"
      style={{
        width: '100%',
        maxWidth: '600px',
        boxSizing: 'border-box',
        margin: 'auto'
      }}
    >
      <Flex
        gap="56px"
        justify="space-around"
        align="center"
        direction="row"
        wrap="wrap"
        p=" 30px 30px 0 30px"
        w="100%"
        style={{
          margin: 'auto',
          boxSizing: 'border-box'
        }}
      >
        <Wrong />
        <p
          style={{
            justifyContent: 'center',
            margin: '0',
            textAlign: 'center'
          }}
        >
          <h1
            style={{
              margin: '0',
              fontWeight: 700,
              fontSize: '110px',
              overflowWrap: 'break-word'
            }}
          >
            404
          </h1>
          <h2 style={{ margin: 0 }}>Page not found</h2>
        </p>
      </Flex>
      <p style={{ textAlign: 'justify' }}>
        Ups! Izgleda da ste zalutali. Žao nam je, ali stranica koju tražite nije
        dostupna. Možda je premještena, obrisana ili ste jednostavno unijeli
        pogrešan URL.
      </p>
      <Button variant="filled" width="100%">
        <Link to="/">Vrati me na početnu</Link>
      </Button>
    </Flex>
  )
}
