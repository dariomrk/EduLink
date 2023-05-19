import { Flex, Image, ScrollArea, Card, Button } from '@mantine/core'
import Tag from '../Tag/index'
import React from 'react'
import { TutorInfo } from '../TutorInfo/TutorInfo.jsx'
import { Link } from 'react-router-dom'

export const OfferCard = props => {
  return (
    <Card shadow="sm" padding="lg" radius="10px" withBorder w="340px" p="16px">
      <Flex
        gap="md"
        justify="flex-start"
        align="center"
        direction="column"
        wrap="wrap"
        style={{
          width: '100%'
        }}
      >
        <Flex
          gap="24px"
          justify="flex-start"
          align="flex-start"
          direction="row"
          wrap="wrap"
          style={{ width: '100%' }}
        >
          <Image
            src={'data:image/png;base64,' + props.user.img}
            width="100"
            height="100"
            radius="10px"
            alt="Profile picture of tutor"
          />
          <div
            style={{
              width: '50%',
              overflowWrap: 'break-word',
              wrap: 'wrap'
            }}
          >
            <TutorInfo
              name={props.user.name}
              stars={props.user.stars}
              review={props.user.review}
              distance={props.user.distance}
            />
          </div>
        </Flex>

        <div>
          <div>Dostupne teme:</div>
          <ScrollArea
            type="hover"
            scrollbarSize={8}
            style={{
              marginTop: '8px',
              width: '320px'
            }}
            offsetScrollbars
          >
            <Flex
              gap="sm"
              justify="flex-start"
              align="flex-start"
              direction="row"
              wrap="nowrap"
            >
              {props.post.tags.map(tag => (
                <Tag tag={tag} key={tag} />
              ))}
            </Flex>
          </ScrollArea>
        </div>

        <Flex
          bg="white"
          justify="space-between"
          direction="row"
          align="flex-start"
          wrap="wrap"
          style={{ width: '100%' }}
        >
          <div
            style={{
              width: '30%',
              overflowWrap: 'break-word'
            }}
          >
            Cijena:
            <div>{props.post.price} €/h</div>
          </div>
          <Button w="70%" variant="filled">
            <Link to={'/posts/' + props.post.id}>Zakaži</Link>
          </Button>
        </Flex>
      </Flex>
    </Card>
  )
}
