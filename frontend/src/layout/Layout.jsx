import React from 'react'
import { Outlet } from 'react-router-dom'

// TODO: Configure Layout
function Layout () {
  return (
      <main>
        <Outlet />
      </main>
  )
}

export default Layout
