import React from 'react'
import {
  createBrowserRouter, createRoutesFromElements, Route, RouterProvider
} from 'react-router-dom'
import NotFoundPage from '../pages/NotFoundPage'
import Register from '../pages/Register'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route path='register' element={<Register/>}/>
      <Route path="*" element={<NotFoundPage/>}/>
    </>
  )
)

function Router () {
  return (<RouterProvider router={router} />)
}

export default Router
