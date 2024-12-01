import React, { useEffect, useState } from 'react';
import { Cliente } from "../models/Cliente";

const ClienteListar = () => {
    const [clientes, setClientes] = useState<Cliente[]>([]);

    useEffect(() => {
        fetch("http://localhost:5122/api/clientes/listar")
            .then(resposta => resposta.json())
            .then(clientes => {
                setClientes(clientes);
            });
    }, []);

    return (
        <div>
            <h1>Lista de Clientes</h1>
            {clientes.length > 0 ? (
            <table border={1}>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Telefone</th>
                        <th>Email</th>
                        <th>Carro Id</th>
                    </tr>
                </thead>
                <tbody>
                    {clientes.map(cliente => (
                        <tr key={cliente.clienteId}>
                            <td>{cliente.clienteId}</td>
                            <td>{cliente.nome}</td>
                            <td>{cliente.telefone}</td>
                            <td>{cliente.email}</td>
                            <td>{cliente.carro?.carroId}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
            ) : (
                <p>Não há clientes cadastrados.</p>
            )}
        </div>
    );
};

export default ClienteListar;
