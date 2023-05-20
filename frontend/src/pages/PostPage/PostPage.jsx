import React, { useState } from 'react'
import {
  Flex,
  Image,
  Checkbox,
  Drawer,
  Group,
  Textarea,
  Button
} from '@mantine/core'
import TutorInfo from '../../components/TutorInfo'
import { useDisclosure } from '@mantine/hooks'
import { Colors } from '../../style/colors'
import { useParams } from 'react-router-dom'
import Tag from '../../components/Tag'
import { posts, users } from '../../data'

export const PostPage = () => {
  const { postId } = useParams()
  const post = posts[postId]
  const user = users[post.userId]
  const [activeStep, setActiveStep] = useState(0)
  const [opened, { open, close }] = useDisclosure(false)

  function handleClick () {
    // check if everything is ok, add to database
  }

  const firstStep = () => {
    return (
      <Drawer
        opened={opened}
        onClose={close}
        title={
          <div
            style={{
              fontSize: '32px',
              fontWeight: '700',
              color: Colors.Title
            }}
          >
            Odaberi temu
          </div>
        }
      >
        <Checkbox.Group
          withAsterisk
          style={{ width: '100%', boxSizing: 'border-box' }}
        >
          <Group mt="xs">{/* tags */}</Group>
        </Checkbox.Group>

        <Textarea
          mt="50px"
          placeholder="Ovdje možete dodati svoju napomenu"
          h="100px"
          withAsterisk
        />
        <Button onClick={() => setActiveStep(activeStep + 1)}>Dalje</Button>
      </Drawer>
    )
  }

  const secondStep = () => {
    return (
      <Drawer
        opened={opened}
        onClose={close}
        title={
          <div
            style={{
              fontSize: '32px',
              fontWeight: '700'
            }}
          >
            Odaberi svoj termin
          </div>
        }
      >
        <Checkbox.Group
          withAsterisk
          style={{ width: '100%', boxSizing: 'border-box' }}
        >
          <Group mt="xs"></Group>
        </Checkbox.Group>

        <Button text="Dalje" onClick={() => handleClick}>
          Button
        </Button>
      </Drawer>
    )
  }

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
          boxSizing: 'border-box',
          color: Colors.Title
        }}
      >
        <Image
          src={
            'data:image/png;base64,' +
            user.img /* + users.filter(u => u.id === post.Id)[0].img */
          }
          style={{ width: '100px', height: '100px' }}
          alt="Profile picture"
          onError={event => {
            event.target.src =
              'https://fastly.picsum.photos/id/737/100/100.jpg?hmac=7gYAJddG5T0oagKYfr9aNJgRUZUyUbU4X0Mq6OGJFRU'
            event.onerror = null
          }}
        />
        <TutorInfo user={user} />

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
              {post.tags.map((tag, index) => (
                <Tag tag={tag} key={index} />
              ))}
            </Flex>
          </div>
        </div>
        <div className="infoWrapper">
          <div className="infoText">Napomena</div>
          <div className="infoTitle">{post.desc}</div>
        </div>

        <div className="infoWrapper">
          <div className="infoText">Cijena</div>
          <div className="infoTitle">{post.price} €/h</div>
        </div>

        <div className="infoWrapper">
          <div className="infoText">Dostupnost</div>
          <div className="infoTitle">--</div>
        </div>

        <Button
          onClick={() => {
            open()
          }}
          width="100%"
        >
          Rezerviraj termin
        </Button>

        {activeStep === 0 ? firstStep() : secondStep()}
      </Flex>
    </div>
  )
}
