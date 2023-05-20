import React from 'react'
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider
} from 'react-router-dom'
import Layout from '../layout'
import HomePage from '../pages/HomePage'
import CategoryPage from '../pages/CategoryPage'
import NotFoundPage from '../pages/NotFoundPage'
import RegisterPage from '../pages/RegisterPage'
import LogInPage from '../pages/LogInPage'
import MessagesPage from '../pages/MessagesPage'
import PostPage from '../pages/PostPage'
import ProfilePage from '../pages/ProfilePage'

const router = createBrowserRouter(
  createRoutesFromElements(
    <>
      <Route element={<Layout />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/login" element={<LogInPage />} />
        <Route path="/messages" element={<MessagesPage />} />
        <Route path="/posts/:postId" element={<PostPage />} />

        <Route path="/profile/:profileId" element={<ProfilePage />} />

        <Route path="category/:categoryName/" element={<CategoryPage />} />
      </Route>
      <Route path="*" element={<NotFoundPage />} />
    </>
  )
)

export function Router () {
  return <RouterProvider router={router} />
}
