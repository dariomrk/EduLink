import React from 'react'
import { Card, Flex } from '@mantine/core'
import { Color } from '../../style/colors'
import { Link } from 'react-router-dom'

export const CategoryCard = props => {
  return (
    <Link to={'category' + props.link} style={{ textDecoration: 'none' }}>
      <Card
        shadow="sm"
        padding="16px"
        withBorder
        radius="10px"
        w="150px"
        style={{
          backgroundColor: Color.CategoryCardPrimary,
          borderColor: Color.CategoryCardBorder,
          textAlign: 'center'
        }}
      >
        <Flex w="100%" gap="8px" align="center" direction="column">
          <div
            style={{
              backgroundColor: props.backgroundColor,
              width: '70px',
              height: '70px'
            }}
          >
            {props.svgContent}
          </div>

          <div
            style={{
              fontSize: '16px',
              fontWeight: 700,
              color: Color.Title
            }}
          >
            {props.name}

            <div style={{ fontSize: '14px', fontWeight: 400 }}>
              {props.numOfInstructor}
              {props.numOfInstructor === 1 ? ' instruktor' : ' instruktora'}
            </div>
          </div>
        </Flex>
      </Card>
    </Link>
  )
}
