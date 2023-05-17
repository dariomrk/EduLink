import React from 'react'
import { Color } from '../../style/colors'
import CategoryCard from '../../components/CategoryCard'
import HomePagePicture from '../../img/HomePagePicture.png'
import CustomButton from '../../components/CustomButton'
import { Flex, ScrollArea } from '@mantine/core'
import PageTitle from '../../components/PageTitle'
import InstructorCard from '../../components/InstructorCard'

export const HomePage = () => {
  return (
    <>
      <PageTitle
        p="125px 20px 170px"
        title="Prilagođene repeticije za svakoga"
        subtitle="Bilo da tražiš nekoga tko će ti pomoći u savladavanju znanja ili si
          voljan postati instruktor i naplaćivati svoje znanje, na pravom si
          mjestu!"
      />

      <Flex
        gap="16px"
        justify="flex-start"
        align="flex-start"
        direction="column"
        style={{
          color: Color.Primary,
          maxWidth: '850px',
          margin: 'auto',
          padding: '24px'
        }}
      >
        <div className="title">Kategorije</div>
        <Flex
          gap="md"
          direction="row"
          wrap="wrap"
          justify="flex-start"
          align="flex-start"
          mb="48px"
        >
          <CategoryCard // add actual data from api
            name="Matematika"
            numOfInstructor={3}
            link="/matematika"
          />
        </Flex>

        <div className="title">Top instruktori</div>
        <ScrollArea // add actual data from api
          type="hover"
          scrollbarSize={8}
          style={{
            marginTop: '8px',
            width: '100%'
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
            <InstructorCard />
            <InstructorCard />
            <InstructorCard />
            <InstructorCard />
            <InstructorCard />
          </Flex>
        </ScrollArea>

        <div
          className="title"
          style={{ textAlign: 'center', marginTop: '98px', width: '100%' }}
        >
          Učenje je lakše uz EduLink!
        </div>
        <CustomButton text="Saznaj više o nama" width="100%" />
        <p style={{ textAlign: 'center' }}>
          Naša platforma povezuje korisnike s iskusnim mentorima koji su
          posvećeni pružanju pomoći u postizanju uspjeha. Bez obzira tražite li
          personaliziranu instrukciju iz određenog područja, pripremu za ispite,
          ili pomoć pri zahtjevnom gradivu, naša zajednica edukatora pruža vam
          savjete i podršku koja vam treba.
        </p>
        <img
          src={HomePagePicture}
          style={{ margin: '30px auto', maxWidth: '100%' }}
          alt="Picture of happy students."
        />
      </Flex>
    </>
  )
}
