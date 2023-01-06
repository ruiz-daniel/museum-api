import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

import 'primereact/resources/primereact.min.css'
import 'primeicons/primeicons.css'
import 'primereact/resources/themes/saga-blue/theme.css'
import 'primeflex/primeflex.css'
import Museums from './pages/Museums'
import Museum from './pages/Museum'

function App() {
  return (
    <Router>
      <Routes>
        <Route path={'/'} element={<Museums />} />
        <Route path={'/museum'} element={<Museum />} />
      </Routes>
    </Router>
  );
}

export default App;
