import React from 'react'
import { Card, Image, Flex, Button } from '@mantine/core'
import TutorInfo from '../TutorInfo'
import { Link } from 'react-router-dom'

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
        <Button width="100%" variant="outline">
          <Link to={'users/' + props.id}> Prikaži više</Link>
        </Button>
      </Flex>
    </Card>
  )
}
