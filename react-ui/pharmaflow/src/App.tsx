import { Outlet, useLocation } from 'react-router-dom';
import './App.css';
import PharmacyTable from './components/pharmacies/PharmacyTable';
import { Container } from 'semantic-ui-react';
import { useEffect, useState } from 'react';
import { setupErrorHandlingInterceptor } from './interceptors/axiosInterceptor';
import { SearchBar } from './components/utilities/SearchBar';

function App() {
  const location = useLocation();
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    setupErrorHandlingInterceptor();
  }, [])

  return (
    <div>
      <Container className='main-style'>
        <SearchBar onSearch={(term => setSearchTerm(term))} />
        {location.pathname === '/' ? (
          <PharmacyTable searchTerm={searchTerm} />) : (
          <Container>
            <Outlet />
          </Container>
        )}
      </Container>
    </div>
  );
}

export default App;