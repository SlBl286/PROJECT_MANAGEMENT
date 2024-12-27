import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { ThemeProvider } from './components/theme-provider.tsx'
import { Toaster } from './components/ui/sonner.tsx'
import { router } from './routes/routes.tsx'
import { RouterProvider } from 'react-router-dom'
import { QueryProvider } from './components/query-provider.tsx'

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ThemeProvider defaultTheme="system" storageKey="vite-ui-theme">
      <QueryProvider>
        <Toaster />
        <RouterProvider router={router} />
      </QueryProvider>
    </ThemeProvider>
  </StrictMode>
)
