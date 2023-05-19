import React from 'react'
import { Flex } from '@mantine/core'
import { ReactComponent as Messages } from '../../img/message.svg'
import { Colors } from '../../style/colors'
import Chats from '../../components/Chats'

export const MessagesPage = () => {
  const numOfMasseges = 0 // all messages of loged in user (get from api)
  function moreMessages () {
    return (
      <>
        <Chats name="ime kontakta" lastMessage="sadrzaj posljednje poruke" />
      </>
    )
  }

  function noMessages () {
    return (
      <>
        <Messages />
        <p
          style={{
            color: Colors.Title,
            fontSize: '16px',
            fontWeight: '400',
            textAlign: 'center'
          }}
        >
          Zasad nemaš poruka. Opcija razgovora s drugim korisnicima je dostupna
          tek nakon rezervacije termina
        </p>{' '}
      </>
    )
  }
  return (
    <Flex
      gap="10px"
      justify="center"
      align="center"
      direction="column"
      m=" 20px auto"
      p="20px"
      w={{ base: '100%', sm: '400px', md: '720px' }}
      style={{ boxSizing: 'border-box' }}
    >
      <h1
        style={{
          textAlign: 'left',
          width: '100%',
          color: Colors.Title,
          fontSize: '20px',
          fontWeight: '700'
        }}
      >
        Poruke
      </h1>

      {numOfMasseges > 1 ? moreMessages() : noMessages()}
    </Flex>
  )
}
