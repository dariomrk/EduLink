import { Flex } from '@mantine/core'
import { ReactComponent as Logo } from '../../img/logo.svg';
import { ReactComponent as Facebook } from '../../img/Facebook.svg';
import { ReactComponent as Instagram } from '../../img/Instagram.svg';
import { ReactComponent as Youtube } from '../../img/Youtube.svg';
import { ReactComponent as LinkedIn } from '../../img/Linkedin.svg';
import { Color } from '../../common';

export const Footer = () => {
  return (
    <Flex
      bg={Color.Primary}
      gap="md"
      justify="center"
      align="center"
      direction="column"
      wrap="wrap"
      style={{
        width: '100%',
        color: '#FFFFFF',
        boxSizing: 'border-box',
        padding: '40px 10px 24px 10px',
        lineHeight: '23.5px',
        textAlign: 'center'
      }}>

      <Flex
        gap="md"
        justify="center"
        align="center"
        direction="column"
        wrap="wrap"
        style={{ marginBottom: '24px' }}>

        <Logo />
        <a>O nama</a>
        <a>FAQ</a>
        <a>Kontakt i pomoć</a>

      </Flex>

      <Flex
        gap="md"
        justify="center"
        align="center"
        direction="column"
        wrap="wrap"
        style={{ marginBottom: '32px' }}>

        <a style={{ fontWeight: 700, fontSize: '20px' }}> {/* <Link> insted of <a>*/}
          Korisni linkovi
        </a>
        <a>Načini plaćanja</a>
        <a>Politika privatnosti</a>
        <a>Uvijeti i pravila korištenja</a>

      </Flex>

      <Flex
        gap="md"
        justify="center"
        align="center"
        direction="row"
        wrap="wrap"
        style={{ marginBottom: '8px' }}>

        <Facebook />
        <Instagram />
        <LinkedIn />
        <Youtube />

      </Flex>

      <span>Copyright © 2023 Edulink</span>
    </Flex>
  )
};
