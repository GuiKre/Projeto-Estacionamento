import { useEffect, useState } from "react";
import axios from "axios";
import { Carro } from "../models/Carro";
import { Cliente } from "../models/Cliente";

function ReciboCadastrar() {
    const [clienteId, setClienteId] = useState("");
    const [carroId, setCarroId] = useState("");
    const [valorTotal, setValorTotal] = useState("");
    const [clientes, setClientes] = useState<Cliente[]>([]);
    const [carros, setCarros] = useState<Carro[]>([]);

  useEffect(() => {
    axios.get('http://localhost:5122/api/clientes/listar')
      .then(response => setClientes(response.data))
      .catch(error => console.error('Erro ao carregar clientes', error));

    axios.get('http://localhost:5122/api/carros/listar')
      .then(response => setCarros(response.data))
      .catch(error => console.error('Erro ao carregar carros', error));
  }, []);

  const handleSubmit = (e: { preventDefault: () => void; }) => {
    e.preventDefault();
    const recibo = { clienteId, carroId, valorTotal };

    axios.post('http://localhost:5122/api/recibos/cadastrar', recibo)
      .then(response => {
        console.log('Recibo gerado', response.data);
      })
      .catch(error => console.error('Erro ao gerar recibo', error));
  };

  return (
    <div>
      <h1>Cadastrar Recibo</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Cliente</label>
          <select value={clienteId} onChange={(e) => setClienteId(e.target.value)} required>
            <option value="">Selecione um cliente</option>
            {clientes.map((cliente) => (
              <option key={cliente.clienteId} value={cliente.clienteId}>{cliente.nome}</option>
            ))}
          </select>
        </div>
        <div>
          <label>Carro</label>
          <select value={carroId} onChange={(e) => setCarroId(e.target.value)} required>
            <option value="">Selecione um carro</option>
            {carros.map((carro) => (
              <option key={carro.carroId} value={carro.carroId}>{carro.placa}</option>
            ))}
          </select>
        </div>
        <div>
          <label>Valor Total</label>
          <input type="number" value={valorTotal} onChange={(e) => setValorTotal(e.target.value)} required />
        </div>
        <button type="submit">Gerar Recibo</button>
      </form>
    </div>
  );
};

export default ReciboCadastrar;