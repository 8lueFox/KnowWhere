import { BrowserRouter, Route, Routes } from 'react-router-dom';
import MapLayout from './Map/MapLayout';
import WelcomePage from './WelcomePage/Welcome'

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route>
          <Route index element={<WelcomePage />} />
          <Route path='/map' element={<MapLayout />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
