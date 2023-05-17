import React from 'react'
import {
  createBrowserRouter, createRoutesFromElements, Route, RouterProvider
} from 'react-router-dom'
import NotFoundPage from '../pages/NotFoundPage'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route path="*" element={<NotFoundPage/>}/>
    </>
  )
)

function Router () {
  return (<RouterProvider router={router} />)
}

export default Router
