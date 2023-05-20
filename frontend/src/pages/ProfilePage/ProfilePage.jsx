import React from 'react'
import { Image, Flex } from '@mantine/core'
import { ReactComponent as Pin } from '../../img/pin.svg'
import { ReactComponent as Verify } from '../../img/verify.svg'
import { Colors } from '../../style/colors'
import { useParams } from 'react-router-dom'

import { users } from '../../data'

export const ProfilePage = () => {
  const { profileId } = useParams()
  const user = users[Number(profileId)]

  return (
    <Flex
      gap="md"
      justify="flex-start"
      align="flex-start"
      direction="column"
      wrap="wrap"
      w="600px"
      p="50px"
      style={{ maxWidth: '100%', boxSizing: 'border-box' }}
      m="auto"
    >
      <Flex
        gap="md"
        justify="flex-start"
        align="flex-start"
        direction="row"
        wrap="wrap"
      >
        <Image
          style={{ width: '70px', height: '70px' }}
          src={'data:image/png;base64,' + user.img}
        />
        <Flex
          gap="md"
          justify="flex-start"
          align="flex-start"
          direction="row"
          wrap="wrap"
        >
          <div className="profile">
            <div className="profileTItle">{user.rating}</div>
            <div className="profileSubtitle">proječna ocjena</div>
          </div>
          <div className="profile">
            <div className="profileTItle">{user.hoursTaught}</div>
            <div className="profileSubtitle">odrađenih sati</div>
          </div>
          <div className="profile">
            <div className="profileTItle">{user.regularStudents}</div>
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
        {user.name}
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
        <div className="profileSubtitle" style={{ overflowWrap: 'break-word' }}>
          Volim [interes/aktivnost], te u slobodno vrijeme najčešće provodim
          vrijeme na [hobi/aktivnost]. Trenutno radim u [zanimanje/industrija],
          no stalno tražim nove načine kako bih se razvijao u tom području i
          proširivao svoje znanje. Životna filozofija mi je da uvijek težim ka
          uspjehu i ispunjenju, te da nikad ne prestajem učiti i istraživati
          nove stvari.
        </div>
      </div>

      <div className="profileWrapper">
        <div className="profileTitle">Recenzije ({user.reviews.length})</div>
        <div className="profileSubtitle">
          <Flex
            gap="16px"
            justify="flex-start"
            align="center"
            direction="row"
            wrap="wrap"
          >
            {/* reviwews */}
          </Flex>
        </div>
      </div>
    </Flex>
  )
}
