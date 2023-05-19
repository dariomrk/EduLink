import React from 'react'
import { Image, Flex } from '@mantine/core'
import { ReactComponent as Pin } from '../../img/pin.svg'
import { ReactComponent as Verify } from '../../img/verify.svg'
import { Colors } from '../../style/colors'

export const ProfilePage = () => {
  return (
    <Flex
      gap="md"
      justify="flex-start"
      align="flex-start"
      direction="column"
      wrap="wrap"
      w="600px"
      p="50px"
      style={{ maxWidth: '100%' }}
      m="auto"
    >
      <Flex
        gap="md"
        justify="flex-start"
        align="flex-start"
        direction="row"
        wrap="wrap"
      >
        <Image style={{ width: '70px', height: '70px' }} />
        <Flex
          gap="md"
          justify="flex-start"
          align="flex-start"
          direction="row"
          wrap="wrap"
        >
          <div className="profile">
            <div className="profileTItle">4,3</div>
            <div className="profileSubtitle">proječna ocjena</div>
          </div>
          <div className="profile">
            <div className="profileTItle">4,3</div>
            <div className="profileSubtitle">odrađenih sati</div>
          </div>
          <div className="profile">
            <div className="profileTItle">4,3</div>
            <div className="profileSubtitle">stalnih studenata</div>
          </div>
        </Flex>
      </Flex>

      <div
        style={{
          fontSize: '20px',
          fontWeight: 700,
          lineHeight: '27px',
          color: Colors.Purple
        }}
      >
        ana
      </div>

      <div
        style={{
          lineHeight: '20px',
          fontSize: '14px',
          gap: '4px',
          display: 'flex',
          flexDirection: 'column'
        }}
      >
        <div className="infos">
          <Pin /> Split, splitsko dalmatinska
        </div>

        <div className="infos">
          {/* isVerified */}
          <Verify />
          Verficiran profil
        </div>
      </div>

      <div className="profileWrapper">
        <div className="profileTitle">O meni</div>
        <div className="profileSubtitle">
          Volim [interes/aktivnost], te u slobodno vrijeme najčešće provodim
          vrijeme na [hobi/aktivnost]. Trenutno radim u [zanimanje/industrija],
          no stalno tražim nove načine kako bih se razvijao u tom području i
          proširivao svoje znanje. Životna filozofija mi je da uvijek težim ka
          uspjehu i ispunjenju, te da nikad ne prestajem učiti i istraživati
          nove stvari.
        </div>
      </div>

      <div className="profileWrapper">
        <div className="profileTitle">Recenzije (3)</div>
        <div className="profileSubtitle">
          <Flex
            gap="16px"
            justify="flex-start"
            align="center"
            direction="row"
            wrap="wrap"
          >
            <Image style={{ width: '70px', height: '70px' }} />
            <div>
              <div
                style={{
                  fontSize: '16px',
                  fontWeight: '500',
                  color: Colors.Subtitle
                }}
              >
                Ana
              </div>
              <div
                style={{
                  fontSize: '14px',
                  fontWeight: '400',
                  color: Colors.Subtitle
                }}
              >
                sve 5
              </div>
            </div>
          </Flex>
        </div>
      </div>
    </Flex>
  )
}
