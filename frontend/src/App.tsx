import { BrowserRouter, Routes, Route } from 'react-router-dom'
import AppShell from './components/layout/AppShell'
import Overview from './pages/Overview'
import Routes_ from './pages/Routes'
import Disruptions from './pages/Disruptions'
import Suggestions from './pages/Suggestions'

export default function App() {
  return (
    <BrowserRouter>
      <AppShell>
        <Routes>
          <Route path="/" element={<Overview />} />
          <Route path="/routes" element={<Routes_ />} />
          <Route path="/disruptions" element={<Disruptions />} />
          <Route path="/suggestions" element={<Suggestions />} />
        </Routes>
      </AppShell>
    </BrowserRouter>
  )
}
