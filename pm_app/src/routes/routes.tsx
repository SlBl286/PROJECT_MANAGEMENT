import Login from "@/app/auth/login/page";
import { createBrowserRouter, redirect } from "react-router-dom";
import NotFoundPage from "@/app/error/not-found";

import { ACCESS_TOKEN_KEY } from "@/config";

import AuthLayout from "@/app/auth/layout";
import MainLayout from "@/app/main/MainLayout";
import DashboardPage from "@/app/main/dashboard/page";
import UserNamePage from "@/app/main/user/user-name";
import RegisterPage from "@/app/auth/register/page";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <MainLayout />,
    loader: async () => {
      const token = localStorage.getItem(ACCESS_TOKEN_KEY);
      if (!token) throw redirect("/auth/login?backUrl=" + window.location.pathname);

      return !!token;
    },
    children: [
      {
        path: "",
        element: <DashboardPage />,
      },
      {
        path: "dashboard",
        element: <DashboardPage />,
      },
      {
        path: "user/:username",
        element: <UserNamePage />,
      },
    ],
  },
  {
    path: "auth",
    loader: async () => {
      const token = localStorage.getItem(ACCESS_TOKEN_KEY);
      if (!!token) throw redirect("/");

      return !!token;
    },
    element: <AuthLayout />,
    children: [
      {
        path: "login",
        element: <Login />,
      },
      {
        path: "register",
        element: <RegisterPage />,
      },
    ],
  },
  {
    path: "*",
    element: <NotFoundPage />,
  },
]);
