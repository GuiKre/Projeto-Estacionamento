import { useEffect, useState } from "react";
import axios from "axios";
import { Vaga } from "../models/Vaga";
import { Carro } from "../models/Carro";

function CarroCadastrar() {
    const [vagas, setVagas] = useState<Vaga[]>([]);
    const [placa, setPlaca] = useState("");
    const [marca, setMarca] = useState("");
    const [modelo, setModelo] = useState("");
    const [cor, setCor] = useState("");
    const [vagaId, setVagaId] = useState(0);

    useEffect(() => {
        axios.get<Vaga[]>("http://localhost:5122/api/vagas/listar")
            .then(resposta => setVagas(resposta.data))
    }, []);

    function enviarCarro(e: any) {
        e.preventDefault();
    
        const carro: Carro = {
            placa: placa,
            marca: marca,
            modelo: modelo,
            cor: cor,
            vagaId: vagaId
        };
    
        axios.post("http://localhost:5122/api/carros/cadastrar", carro)
            .then(resposta => {
                console.log("Carro cadastrado!", resposta.data);
            })
            .catch(erro => {
                console.log("Erro ao cadastrar carro", erro);
            });
    }    

    return (
        <div>
            <h1>Cadastrar Carro</h1>
            <form onSubmit={enviarCarro}>
                <div>
                    <label>Placa:</label>
                    <input type="text" value={placa} onChange={(e) => setPlaca(e.target.value)} required />
                </div>
                <div>
                    <label>Marca:</label>
                    <input type="text" value={marca} onChange={(e) => setMarca(e.target.value)} required />
                </div>
                <div>
                    <label>Modelo:</label>
                    <input type="text" value={modelo} onChange={(e) => setModelo(e.target.value)} required />
                </div>
                <div>
                    <label>Cor:</label>
                    <input type="text" value={cor} onChange={(e) => setCor(e.target.value)} required />
                </div>
                <div>
                    <label>Vaga:</label>
                    <select value={vagaId} onChange={(e) => setVagaId(parseInt(e.target.value))}>
                        <option value={0}>Selecione a vaga</option>
                        {vagas.map(vaga => (
                            <option key={vaga.vagaId} value={vaga.vagaId}>{vaga.numero}</option>
                        ))}
                    </select>
                </div>
                <button type="submit">Cadastrar</button>
            </form>
        </div>
    );
}

export default CarroCadastrar;
