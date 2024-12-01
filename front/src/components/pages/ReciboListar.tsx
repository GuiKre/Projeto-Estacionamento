import React, { useEffect, useState } from 'react';
import { Recibo } from "../models/Recibo";
import axios from 'axios';

function ReciboListar() {
  const [recibos, setRecibos] = useState<Recibo[]>([]);

  useEffect(() => {
    axios
      .get('http://localhost:5122/api/recibos/listar')
      .then((response) => setRecibos(response.data))
      .catch((error) => console.error('Erro ao listar recibos', error));
  }, []);

  return (
    <div>
      <h1>Lista de Recibos</h1>
      {recibos.length > 0 ? (
        <table border={1}>
          <thead>
            <tr>
              <th>ID</th>
              <th>Data de Criação</th>
              <th>Valor Total</th>
              <th>ID Cliente</th>
              <th>ID Carro</th>
            </tr>
          </thead>
          <tbody>
            {recibos.map((recibo) => (
              <tr key={recibo.reciboId}>
                <td>{recibo.reciboId}</td>
                <td>{recibo.dataCriacao ? new Date(recibo.dataCriacao).toLocaleDateString() : 'N/A'}</td>
                <td>{recibo.valorTotal}</td>
                <td>{recibo.clienteId}</td>
                <td>{recibo.carroId}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p>Não há recibos cadastrados.</p>
      )}
    </div>
  );
}

export default ReciboListar;