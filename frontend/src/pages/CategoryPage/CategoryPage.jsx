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

        {/* {...(() => (
          <OfferCard />
        ))} */}
      </Flex>
    </div>
  )
}
