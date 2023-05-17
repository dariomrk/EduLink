import React from 'react'
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider
} from 'react-router-dom'
import Layout from '../layout'
import HomePage from '../pages/HomePage'
import NotFoundPage from '../pages/NotFoundPage'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route element={<Layout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="category/:categoryName" />
      </Route>
      <Route path="*" element={<NotFoundPage />} />
    </>
  )
)

export function Router () {
  return <RouterProvider router={router} />
}
