import { Flex, Image, ScrollArea, Card } from '@mantine/core'
import Tag from '../Tag/index'
import React from 'react'
import { CustomButton } from '../CustomButton/CustomButton.jsx'
import { TutorInfo } from '../TutorInfo/TutorInfo.jsx'

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
            src={'data:image/png;base64,' + props.img}
            width="114"
            height="81"
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
              name={props.name}
              stars={props.stars}
              review={props.review}
              distance={props.distance}
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
              {props.tags.map(tag => {
                return <Tag tag={tag} key={tag}></Tag>
              })}
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
            <div>{props.price} €/h</div>
          </div>
          <CustomButton width="70%" text="Zakaži" variant="filled" />
        </Flex>
      </Flex>
    </Card>
  )
}
