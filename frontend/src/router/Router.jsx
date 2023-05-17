import React from 'react'
import {
  createBrowserRouter, createRoutesFromElements, RouterProvider
} from 'react-router-dom'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      {/* // TODO: NotFoundPage <Route path="*" element={<NotFoundPage />} /> */}
    </>
  )
)

function Router () {
  return (<RouterProvider router={router} />)
}

export default Router
