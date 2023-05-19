import React from 'react'
import { Image, Flex } from '@mantine/core'
import TutorInfo from '../../components/TutorInfo'

export const ProfilePage = () => {
  return (
    <Flex
      gap="md"
      justify="flex-start"
      align="flex-start"
      direction="column"
      wrap="wrap"
    >
      <Flex
        gap="md"
        justify="flex-start"
        align="flex-start"
        direction="row"
        wrap="wrap"
      >
        <Image w="70px" h="70px" />
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

          <TutorInfo />
          
        </Flex>
      </Flex>
    </Flex>
  )
}
