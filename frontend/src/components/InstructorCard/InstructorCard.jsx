import React from 'react'
import { Card, Image, Flex } from '@mantine/core'
import CustomButton from '../CustomButton'
import TutorInfo from '../TutorInfo'

export const InstructorCard = props => {
  return (
    <Card shadow="sm" padding="lg" radius="md" withBorder w="220px" p="16px">
      <Flex
        gap="8px"
        justify="flex-start"
        align="flex-start"
        direction="column"
        wrap="wrap"
      >
        <Image
          src={'data:image/png;base64,' + props.img}
          style={{ width: '185px', height: '170px' }}
          radius="8px"
        />
        <TutorInfo
          name={props.name}
          stars={props.stars}
          review={props.review}
          distance={props.distance}
          isVerified={true}
        />
        <CustomButton width="100%" variant="outline" text="Prikaži više" />
      </Flex>
    </Card>
  )
}
