import React from 'react'
import { Card, Image, Flex } from '@mantine/core'
import CustomButton from '../CustomButton'
import TutorInfo from '../TutorInfo'

export const InstructorCard = props => {
  return (
    <Card
      shadow="sm"
      padding="lg"
      radius="md"
      withBorder
      w='220px'
      p="16px"
    >
      <Flex
        gap="8px"
        justify="flex-start"
        align="flex-start"
        direction="column"
        wrap="wrap"
      >
        <Image
          src="https://images.unsplash.com/photo-1527004013197-933c4bb611b3?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=720&q=80"
          style={{ width: '100%' }}
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
