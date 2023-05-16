import { Flex, Image, ScrollArea } from '@mantine/core'
import { Color } from '../../style/colors.js'
import Tag from '../Tag/index'
import React from 'react'
import { CustomButton } from '../CustomButton/CustomButton.jsx'

import { ReactComponent as Distance } from '../../img/distance.svg'
import { ReactComponent as Star } from '../../img/star.svg'

export const OfferCard = (props) => {
  return (
    <div style={{
      boxSizing: 'border-box',
      display: 'flex',
      alignContent: 'center',
      borderRadius: '10px',
      width: '340px',
      padding: '16px',
      backgroundColor: '#FFFFFF'
    }}>

      <Flex
        gap='md'
        justify='flex-start'
        align='center'
        direction='column'
        wrap='wrap'
        style={{
          width: '100%',
          color: Color.Button
        }}
      >
        <Flex
          gap='24px'
          justify='flex-start'
          align='flex-start'
          direction='row'
          wrap='wrap'
          style={{ width: '100%' }}
        >
          <Image
            src={'data:image/png;base64,' + props.img}
            width='114'
            height='81'
            radius='10px'
            alt='Profile picture of tutor'
          />

          <div style={{
            width: '170px',
            overflowWrap: 'break-word',
            wrap: 'wrap',
            gap: '8px'
          }}>
            <div style={{
              color: Color.Title,
              fontSize: '20px',
              fontWeight: 700,
              lineHeight: '27px'
            }}>
              {props.name}
            </div>

            <div style={{
              lineHeight: '20px',
              fontSize: '14px',
              gap: '4px',
              display: 'flex',
              flexDirection: 'column'
            }}>

              <div style={{
                display: 'flex',
                alignItems: 'center',
                gap: '4px'
              }}>
                <Distance /> {props.distance} km od tebe
              </div>

              <div style={{
                display: 'flex',
                alignItems: 'center',
                gap: '4px'
              }}>
                <Star /> {props.start}
                <a style={{ textDecoration: 'underline' }}>Recenzije ({props.review})</a>
              </div>
            </div>
          </div>
        </Flex>

        <div>
          <div>Dostupne teme:</div>
          <ScrollArea
            type='hover'
            scrollbarSize={8}
            style={{
              marginTop: '8px',
              width: '320px'
            }}
            offsetScrollbars>

            <Flex
              gap='sm'
              justify='flex-start'
              align='flex-start'
              direction='row'
              wrap='nowrap'
            >
              {props.tags.map((tag) => {
                return (<Tag tag={tag} key={tag}></Tag>)
              })
              }
            </Flex>
          </ScrollArea>
        </div>

        <Flex
          bg='white'
          justify='space-between'
          direction='row'
          align='flex-start'
          wrap='wrap'
          style={{ width: '100%' }}
        >
          <div style={{
            width: '30%',
            overflowWrap: 'break-word'
          }}>
            Cijena:
            <div>{props.price} €/h</div>
          </div>

          <CustomButton
            width='70%'
            text='Zakaži'
            variant='filled' />
        </Flex>
      </Flex>
    </div>
  )
}
