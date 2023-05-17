import React, { useState } from 'react'

const registrationStep = Object.freeze({
  userInfo: 0,
  identityInfo: 1,
  verification: 2
})

function Register () {
  const [step, setRegistrationStep] = useState(0)

  switch (step) {
    case registrationStep.userInfo:
      return (<>
      </>)

    case registrationStep.identityInfo:
      return (<>
      </>)

    case registrationStep.verification:
      return (<>
      </>)

    default:
      throw new Error()
  }
}

export default Register
