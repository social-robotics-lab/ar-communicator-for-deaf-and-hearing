import React from 'react'
import ReactDOM from 'react-dom/client'
import Header from './components/header/Header.tsx'
import Router from './routers/Router.tsx'
import { UsersInfoProvider } from './providers/UsersInfoProvider.tsx'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Header />
    <UsersInfoProvider>
      <Router />
    </UsersInfoProvider>
  </React.StrictMode>,
)
