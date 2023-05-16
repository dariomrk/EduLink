import React from 'react'
import { Color } from '../../style/colors'
import { ReactComponent as Distance } from '../../img/distance.svg'
import { ReactComponent as Star } from '../../img/star.svg'
import { ReactComponent as Verify } from '../../img/verify.svg'

export const TutorInfo = props => {
  return (
    <div
      style={{
        maxWidth: '100%',
        overflowWrap: 'break-word',
        wrap: 'wrap',
        gap: '8px',
        color: Color.Button
      }}
    >
      <div
        style={{
          color: Color.Title,
          fontSize: '20px',
          fontWeight: 700,
          lineHeight: '27px'
        }}
      >
        {props.name}
      </div>

      <div
        style={{
          lineHeight: '20px',
          fontSize: '14px',
          gap: '4px',
          display: 'flex',
          flexDirection: 'column'
        }}
      >
        <div className="infos">
          <Distance /> {props.distance} km od tebe
        </div>

        <div className="infos">
          <Star /> {props.stars}
          <a style={{ textDecoration: 'underline' }}>
            Recenzije ({props.review})
          </a>
        </div>

        {props.isVerified
          ? (
          <div className="infos">
            <Verify />
            Verficiran profil
          </div>
            )
          : null}
      </div>
    </div>
  )
}
