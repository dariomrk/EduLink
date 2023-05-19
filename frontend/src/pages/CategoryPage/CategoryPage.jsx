import React from 'react'
import { useParams } from 'react-router-dom'
import PageTitle from '../../components/PageTitle'
import { Flex } from '@mantine/core'
import Sort from '../../components/Sort'
import Filter from '../../components/Filter'
import OfferCard from '../../components/OfferCard'

export const CategoryPage = () => {
  const { categoryName } = useParams()
  const numOfInstructor = 0 // get from db
  const data = ['ana', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j']
  const post = [
    {
      id: '58',
      tags: ['tag1', 'tag2', 'tag3']
    },

    {
      tags: ['tag1', 'tag2', 'tag3']
    }
  ]
  return (
    <div>
      <PageTitle
        padding="125px 20px 170px"
        title={categoryName}
        subtitle={
          numOfInstructor === 1
            ? numOfInstructor + ' instruktor'
            : numOfInstructor + ' instruktora'
        }
        p="57px 20px"
      />

      <Flex
        p="16px 0"
        w={{ base: '340px', md: '696px', lg: '1052px' }}
        gap="16px"
        justify="flex-start"
        align="flex-start"
        direction="row"
        wrap="wrap"
        style={{ margin: 'auto' }}
      >
        <Flex align="center" w="100%">
          <Sort />
          <Filter />
        </Flex>

        {post.map((x, index) => (
          <OfferCard post={x} user={{ name: data[0] }} key={index} />
        ))}
      </Flex>
    </div>
  )
}
