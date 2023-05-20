import React from 'react'
import { Card, Flex } from '@mantine/core'
import { Colors } from '../../style/colors'
import { Link } from 'react-router-dom'

export const CategoryCard = props => {
  return (
    <Link to={'category/' + props.name}>
      <Card
        shadow="sm"
        padding="16px"
        withBorder
        radius="10px"
        w="156px"
        h="156px"
        style={{
          backgroundColor: Colors.WhiteBg,
          textAlign: 'center'
        }}
      >
        <Flex w="100%" gap="8px" align="center" direction="column">
          {props.svg}

          <div
            style={{
              fontSize: '16px',
              fontWeight: 700,
              color: Colors.Title,
              textTransform: 'capitalize'
            }}
          >
            {props.name}
            <div
              style={{
                fontSize: '14px',
                fontWeight: 400,
                color: Colors.Subtitle
              }}
            >
              {props.numOfInstructor}
              {props.numOfInstructor >= 2 && props.numOfInstructor <= 4
                ? ' instrukcije'
                : ' instruktora'}
            </div>
          </div>
        </Flex>
      </Card>
    </Link>
  )
}
