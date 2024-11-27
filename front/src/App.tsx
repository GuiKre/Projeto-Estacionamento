import React from 'react';
import './App.css';
import { BrowserRouter, Link, Route, Routes } from 'react-router-dom';
import VagaListar from "./components/pages/vaga/VagaListar";
import VagaCadastrar from './components/pages/vaga/VagaCadastrar';

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
            <Link to="/pages/vagas/consultar">Consultar Vagas</Link>
          </li>
        </ul>
        </nav>

        <Routes>
          <Route path='/' element={<VagaListar/>}/>
          <Route path='/pages/vagas/listar' element={<VagaListar/>}/>
          <Route path='/pages/vagas/cadastrar' element={<VagaCadastrar/>}/>
          {/* 
          <Route path='/pages/vagas/consultar' element={<VagaConsultar/>}/>
          <Route path='/pages/vagas/alterar/:id' element={<VagaAlterar/>}/> */}
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
