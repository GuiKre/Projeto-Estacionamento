import React, { useState, useEffect } from 'react';
import { Cliente } from "../models/Cliente";
import axios from 'axios';

function ClienteCadastro(){
    const [, setClientes] = useState<Cliente[]>([]);
    const [clienteId, setClienteId] = useState(0);
    const [nome, setNome] = useState<string>('');
    const [telefone, setTelefone] = useState<string>('');
    const [email, setEmail] = useState<string>('');
    const [carroId] = useState(0);

    useEffect(() => {
        axios.get<Cliente[]>("http://localhost:5122/api/clientes/listar")
            .then((resposta) => {
                setClientes(resposta.data);
            })
    })

    function enviarCliente(e : any){
        e.preventDefault();

        const cliente : Cliente = {
            clienteId : clienteId,
            nome : nome,
            telefone: telefone,
            email: email,
            carroId: carroId
        }

        fetch("http://localhost:5122/api/clientes/cadastrar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(cliente)
            })
            .then(resposta => {
                return resposta.json();
            })
            .then(cliente => {
                console.log("Cliente cadastrado!", cliente)
            })

    }

    return (
        <div id="cadastrar_cliente">
            <h1>Cadastrar Cliente</h1>

            <form onSubmit={enviarCliente}>
                <div className="divs">
                    <label htmlFor="clienteId">Cliente ID:</label>
                    <input type="number" id="clienteId" name="clienteId" onChange={(e : any) => setClienteId(parseInt(e.target.value))}  />
                </div>
                
                <div className="divs">
                    <label htmlFor="nome">Nome:</label>
                    <input type="text" id="nome" name="nome" onChange={(e : any) => setNome(e.target.value)}  />
                </div>

                <div className="divs">
                    <label htmlFor="telefone">Telefone:</label>
                    <input type="text" id="telefone" name="telefone" onChange={(e : any) => setTelefone(e.target.value)}  />
                </div>

                <div className="divs">
                    <label htmlFor="email">Email:</label>
                    <input type="text" id="email" name="email" onChange={(e : any) => setEmail(e.target.value)}  />
                </div>

                <button type="submit" id="btn_cadastrar">Cadastrar</button>
            </form>
        </div>
    );
};

export default ClienteCadastro;
