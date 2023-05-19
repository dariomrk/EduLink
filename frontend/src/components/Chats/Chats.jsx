import React from 'react'
import { Flex, Image } from '@mantine/core'

export const Chats = props => {
  return (
    <Flex
      w="100%"
      gap="20px"
      justify="flex-start"
      align="center"
      direction="row"
      wrap="wrap"
      p="20px 0 20px 0"
      m="0"
    >
      <Image
        src={'data:image/png;base64,' + props.img}
        alt="User profile image"
        width="80px"
        height="80px"
        style={{
          borderRadius: '100px'
        }}
        onError={event => {
          event.target.src =
            'https://img.wattpad.com/8f19b412f2223afe4288ed0904120a48b7a38ce1/68747470733a2f2f73332e616d617a6f6e6177732e636f6d2f776174747061642d6d656469612d736572766963652f53746f7279496d6167652f5650722d38464e2d744a515349673d3d2d3234323931353831302e313434336539633161633764383437652e6a7067?s=fit&w=720&h=720'
          event.onerror = null
        }}
      />
      <div>
        <div style={{ fontSize: '16px', fontWeight: '600' }}>{props.name}</div>
        <div style={{ fontSize: '16px', fontWeight: '400' }}>
          {props.lastMessage}
        </div>
      </div>
    </Flex>
  )
}
