import React from 'react'
import ReactDOM from 'react-dom/client'
import Home from './pages/Home.tsx'
import Header from './components/header/Header.tsx'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Header />
    <Home />
  </React.StrictMode>,
)
