import React from 'react'
import { Image, Flex } from '@mantine/core'
import TutorInfo from '../../components/TutorInfo'
import { Colors } from '../../style/colors'
export const ProfilePage = () => {
  return (
    <Flex
      gap="24px"
      justify="flex-start"
      align="flex-start"
      direction="flex-start"
      wrap="wrap"
      p="24px"
      w="100%"
      style={{ maxWidth: '500px' }}
      m="auto"
    >
      <Flex
        gap="md"
        justify="flex-start"
        align="flex-start"
        direction="row"
        wrap="wrap"
      >
        <Flex
          gap="md"
          justify="flex-start"
          align="flex-start"
          direction="row"
          wrap="wrap"
        >
          <Image style={{ width: '80px', height: '80px' }} />
          <div className="profile">
            <div className="profileTItle">4,3</div>
            <div className="profileSubtitle">proječna ocjena</div>
          </div>
          <div className="profile">
            <div className="profileTItle">4,3</div>
            <div className="profileSubtitle">odrađenih sati</div>
          </div>
          <div className="profile">
            <div className="profileTItle">4,3</div>
            <div className="profileSubtitle">stalnih studenata</div>
          </div>
        </Flex>
      </Flex>

      <TutorInfo />
      <div className="infoWrapper">
        <div className="infoTitle">Područje</div>
        <div className="infoText">Matematika</div>
      </div>

      <div className="infoWrapper">
        <div className="infoTitle">O meni</div>
        <div className="infoText">
          Volim [interes/aktivnost], te u slobodno vrijeme najčešće provodim
          vrijeme na [hobi/aktivnost]. Trenutno radim u [zanimanje/industrija],
          no stalno tražim nove načine kako bih se razvijao u tom području i
          proširivao svoje znanje. Životna filozofija mi je da uvijek težim ka
          uspjehu i ispunjenju, te da nikad ne prestajem učiti i istraživati
          nove stvari.
        </div>
      </div>

      <div className="infoWrapper">
        <div className="infoTitle">Recenzije (numberOfReviews)</div>
        <div className="infoText">
          <Flex
            p="24px 0"
            gap="8px"
            justify="flex-start"
            align="flex-start"
            direction="row"
            w="100%"
          >
            <Image
              style={{ width: '80px', height: '80px' }}
              src="https://picsum.photos/80/80"
            />
            <div>
              <div
                style={{
                  fontWeight: '500',
                  color: Colors.Title
                }}
              >
                Ana123
              </div>
              <div>
                Ivana odlično prilagodi tempo objašnjavanja i lako se dogovoriti
                s njom. Ispit položen tako da hvala na pomoći!
              </div>
            </div>
          </Flex>
        </div>
      </div>
    </Flex>
  )
}
