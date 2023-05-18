import React from 'react'
import { Flex, Image } from '@mantine/core'
import TutorInfo from '../../components/TutorInfo'
import CustomButton from '../../components/CustomButton'
import Tag from '../../components/Tag'

export const PostPage = () => {
  return (
    <div>
      <Flex
        gap="20px"
        justify="flex-start"
        align="flex-start"
        direction="row"
        wrap="wrap"
        p="64px 24px"
        w={{ base: '100%', md: '500px', lg: '1000px' }}
        m="auto"
        style={{
          boxSizing: 'border-box'
        }}
      >
        <Image
          src={
            'data:image/png;base64,' /* + users.img */
          }
          style={{ width: '100px', height: '100px' }}
          alt="Profile picture"
          onError={event => {
            event.target.src =
              'https://fastly.picsum.photos/id/737/100/100.jpg?hmac=7gYAJddG5T0oagKYfr9aNJgRUZUyUbU4X0Mq6OGJFRU'
            event.onerror = null
          }}
        />
        <TutorInfo user={{ name: '' }} />

        <div className="infoWrapper">
          <div className="infoText">Područje</div>
          <div className="infoTitle">Matematika</div>
        </div>

        <div className="infoWrapper">
          <div className="infoText">Tema</div>
          <div className="infoTitle">
            <Flex
              m="12px 0"
              p="0"
              gap="12px"
              justify="flex-start"
              align="flex-start"
              direction="row"
              wrap="wrap"
            >
              {/* {post.tags.map(tag => { */}
              <Tag tag="a"></Tag>
              {/*               })}
               */}{' '}
            </Flex>
          </div>
        </div>
        <div className="infoWrapper">
          <div className="infoText">Napomena</div>
          <div className="infoTitle">--</div>
        </div>

        <div className="infoWrapper">
          <div className="infoText">Cijena</div>
          <div className="infoTitle">3.20€/h</div>
        </div>

        <div className="infoWrapper">
          <div className="infoText">Dostupnost</div>
          <div className="infoTitle">Popodnevni termini</div>
        </div>

        <CustomButton
          text="Rezerviraj termin"
          onClick={() => {
            handleClick() 
          }}
          width="100%"
          disable={false} // TODO: check is user is logged in
        />
      </Flex>
    </div>
  )
}
