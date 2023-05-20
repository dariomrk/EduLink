import React from 'react'
import { ReactComponent as Distance } from '../../img/distance.svg'
import { ReactComponent as Star } from '../../img/star.svg'
import { ReactComponent as Verify } from '../../img/verify.svg'
import { Link } from 'react-router-dom'

export const TutorInfo = props => {
  return (
    <div
      style={{
        maxWidth: '100%',
        overflowWrap: 'break-word',
        wrap: 'wrap',
        gap: '8px'
      }}
    >
      <Link to={'/profile/' + props.user.id}>
        <div
          style={{
            fontSize: '20px',
            fontWeight: 700,
            lineHeight: '27px'
          }}
        >
          {props.user.name}
        </div>
      </Link>

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
          <Distance /> {props.user.distance} km od tebe
        </div>

        <div className="infos">
          <Star /> {props.user.stars}
          <a style={{ textDecoration: 'underline' }}>
            Recenzije ({props.user.reviews.length})
          </a>
        </div>

        {props.user.isVerified
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
