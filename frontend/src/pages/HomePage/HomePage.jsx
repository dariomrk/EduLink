import React from 'react'
import { Colors } from '../../style/colors'
import CategoryCard from '../../components/CategoryCard'
import HomePagePicture from '../../img/HomePagePicture.png'
import { Flex, ScrollArea, Button } from '@mantine/core'
import PageTitle from '../../components/PageTitle'
import InstructorCard from '../../components/InstructorCard'
import { ReactComponent as Math } from '../../img/category/math.svg'
import { ReactComponent as Physics } from '../../img/category/physics.svg'
import { ReactComponent as Programming } from '../../img/category/programming.svg'
import { ReactComponent as Design } from '../../img/category/design.svg'
import { ReactComponent as Marketing } from '../../img/category/marketing.svg'
import { ReactComponent as Language } from '../../img/category/language.svg'

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
        p="50px 0"
        w={{ base: '328px', sm: '500px', lg: '1016px' }}
        m="auto"
        style={{
          boxSizing: 'border-box'
        }}
      >
        <div className="title">Kategorije</div>
        <Flex
          gap="16px"
          direction="row"
          wrap="wrap"
          justify="flex-start"
          align="flex-start"
          mb="48px"
          w="100  "
        >
          <CategoryCard
            name="Matematika"
            numOfInstructor={3}
            svg={<Math> /</Math>}
          />

          <CategoryCard name="Fizika" numOfInstructor={3} svg={<Physics />} />

          <CategoryCard
            name="Programiranje"
            numOfInstructor={3}
            svg={<Programming />}
          />

          <CategoryCard name="Dizajn" numOfInstructor={3} svg={<Design />} />

          <CategoryCard
            name="Marketing"
            numOfInstructor={3}
            svg={<Marketing />}
          />

          <CategoryCard
            name="Strani jezici"
            numOfInstructor={3}
            svg={<Language />}
          />
        </Flex>
        <div className="title">Top instruktori</div>
        <ScrollArea // TODO: add top instructors
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
        <Button width="100%"> Saznaj više o nama</Button>
        <p style={{ textAlign: 'center', color: Colors.Text }}>
          Naša platforma povezuje korisnike s iskusnim mentorima koji su
          posvećeni pružanju pomoći u postizanju uspjeha. Bez obzira tražite li
          personaliziranu instrukciju iz određenog područja, pripremu za ispite,
          ili pomoć pri zahtjevnom gradivu, naša zajednica edukatora pruža vam
          savjete i podršku koja vam treba.
        </p>
        <img
          src={HomePagePicture}
          style={{ margin: '30px auto', maxWidth: '100%' }}
          alt="Picture of students."
        />
      </Flex>
    </>
  )
}
