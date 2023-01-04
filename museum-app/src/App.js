import { BrowserRouter as Router, Routes, Route } from 'react-router-dom'

import 'primereact/resources/primereact.min.css'
import 'primeicons/primeicons.css'
import 'primereact/resources/themes/saga-blue/theme.css'
import 'primeflex/primeflex.css'
import Museums from './pages/Museums'

function App() {
  return (
    <Router>
      <Routes>
        <Route path={'/'} element={<Museums />} />
      </Routes>
    </Router>
  );
}

export default App;
