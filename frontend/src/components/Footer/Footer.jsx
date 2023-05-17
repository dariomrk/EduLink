import React from 'react'
import { Flex } from '@mantine/core'
import { ReactComponent as Logo } from '../../img/logo.svg'
import { ReactComponent as Facebook } from '../../img/Facebook.svg'
import { ReactComponent as Instagram } from '../../img/Instagram.svg'
import { ReactComponent as Youtube } from '../../img/Youtube.svg'
import { ReactComponent as LinkedIn } from '../../img/Linkedin.svg'
import { Color } from '../../style/colors'
import { Link } from 'react-router-dom'

export const Footer = () => {
  return (
    <Flex
      bg={Color.Primary}
      gap="md"
      justify="center"
      align="center"
      direction="column"
      wrap="wrap"
      p="40px 10px 24px 10px"
      style={{
        width: '100%',
        color: Color.White,
        boxSizing: 'border-box',
        lineHeight: '23.5px',
        textAlign: 'center'
      }}
    >
      <Flex
        gap="md"
        justify="center"
        align="center"
        direction="column"
        wrap="wrap"
        mb="24px"
      >
        <Logo />
        <Link to="about">O nama</Link>
        <Link to="faq">FAQ</Link>
        <Link to="help">Kontakt i pomoć</Link>
      </Flex>

      <Flex
        gap="md"
        justify="center"
        align="center"
        direction="column"
        wrap="wrap"
        mb="32px"
      >
        <Link
          to="usefulLinks"
          style={{
            fontWeight: 700,
            fontSize: '20px'
          }}
        >
          Korisni linkovi
        </Link>
        <Link to="paymentMethods">Načini plaćanja</Link>
        <Link to="privacyPolicy">Politika privatnosti</Link>
        <Link to="termsAndCoonditions">Uvijeti i pravila korištenja</Link>
      </Flex>

      <Flex
        gap="md"
        justify="center"
        align="center"
        direction="row"
        wrap="wrap"
        mb="8px"
      >
        <Facebook />
        <Instagram />
        <LinkedIn />
        <Youtube />
      </Flex>

      <span>Copyright © 2023 Edulink</span>
    </Flex>
  )
}
