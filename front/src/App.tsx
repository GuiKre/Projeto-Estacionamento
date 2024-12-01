import React from 'react';
import './App.css';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import VagaListar from "./components/pages/VagaListar";
import VagaCadastrar from './components/pages/VagaCadastrar';
import CarroCadastrar from './components/pages/CarroCadastrar';
import CarroListar from './components/pages/CarroListar';
import ClienteCadastrar from './components/pages/ClienteCadastrar';
import ClienteListar from './components/pages/ClienteListar';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/pages/vagas/listar">Listar Vagas</Link>
          </li>
          <li>
            <Link to="/pages/vagas/cadastrar">Cadastrar Vagas</Link>
          </li>
          <li>
            <Link to="/pages/CarroCadastrar">Cadastrar Carro</Link>
          </li>
          <li>
            <Link to="/pages/CarroListar">Listar Carros</Link>
          </li>
          <li>
            <Link to="/pages/vagas/consultar">Consultar Vagas</Link>
          </li>
          <li>
            <Link to="/pages/ClienteCadastrar">Cadastrar Clientes</Link>
          </li>
          <li>
            <Link to="/pages/ClienteListar">Listar Clientes</Link>
          </li>
        </ul>
        </nav>

        <Routes>
          <Route path='/' element={<VagaListar/>}/>
          <Route path='/pages/vagas/listar' element={<VagaListar/>}/>
          <Route path='/pages/vagas/cadastrar' element={<VagaCadastrar/>}/>
          <Route path='/pages/CarroCadastrar' element={<CarroCadastrar/>}/>
          <Route path='/pages/CarroListar' element={<CarroListar/>}/>
          <Route path='/pages/ClienteCadastrar' element={<ClienteCadastrar/>}/>
          <Route path='/pages/ClienteListar' element={<ClienteListar/>}/>

          {/* 
          <Route path='/pages/vagas/consultar' element={<VagaConsultar/>}/>
          <Route path='/pages/vagas/alterar/:id' element={<VagaAlterar/>}/> */}
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
