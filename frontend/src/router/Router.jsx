import React from 'react'
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider
} from 'react-router-dom'
import Layout from '../layout'
import HomePage from '../pages/HomePage'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route element={<Layout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="category/:categoryName" />
      </Route>
    </>
  )
)

export function Router () {
  return <RouterProvider router={router} />
}
