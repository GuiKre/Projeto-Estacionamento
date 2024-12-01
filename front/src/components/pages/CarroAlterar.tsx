import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Vaga } from "../models/Vaga";
import axios from "axios";
import { Carro } from "../models/Carro";

function CarroAlterar(){
    const{ id } = useParams();
    const [vagas, setVagas] = useState<Vaga[]>([]);
    const [placa, setPlaca] = useState<string>('');
    const [marca, setMarca] = useState<string>('');
    const [modelo, setModelo] = useState<string>("");
    const [cor, setCor] = useState<string>("");
    const [vagaId, setVagaId] = useState(0);

    useEffect(() => {
        if(id){
            axios.get<Carro>(`http://localhost:5122/api/carros/buscar/${id}`)
            .then(resposta => {
                setPlaca(resposta.data.placa);
                setMarca(resposta.data.marca);
                setModelo(resposta.data.modelo);
                setCor(resposta.data.cor);
                setVagaId(resposta.data.vagaId);
                buscarVagas();
            })
        }
    }, []);

    function buscarVagas(){
        axios.get<Vaga[]>("http://localhost:5122/api/vagas/listar")
            .then((resposta) => {
                setVagas(resposta.data);
            });
    }

    function enviarCarro(e : any){
        e.preventDefault();

        const carro : Carro = {
            placa : placa,
            marca : marca,
            modelo : modelo,
            cor : cor,
            vagaId : vagaId,
        };

        axios.put(`http://localhost:5122/api/carros/alterar/${id}`, carro)
        .then(resposta => {
            console.log(resposta.data);
        })
    }

    return(
        <div id="alterar-carro">
            <h1>Alterar Carro</h1>

            <form onSubmit={enviarCarro}>
                <div className="divs">
                    <label htmlFor="placa">Placa:</label>
                    <input type="text" id="placa" name="placa" value={placa} onChange={(e : any) => setPlaca(e.target.value)}  />
                </div>
                
                <div className="divs">
                    <label htmlFor="marca">Marca:</label>
                    <input type="text" id="marca" name="marca" value={marca} onChange={(e : any) => setMarca(e.target.value)}  />
                </div>

                <div className="divs">
                    <label htmlFor="modelo">Modelo:</label>
                    <input type="text" id="modelo" name="modelo" value={modelo} onChange={(e : any) => setModelo(e.target.value)}  />
                </div>

                <div className="divs">
                    <label htmlFor="cor">Cor:</label>
                    <input type="text" id="cor" name="cor" value={cor} onChange={(e : any) => setCor(e.target.value)}  />
                </div>

                <div>
                    <label>Vaga:</label>
                    <select value={vagaId} onChange={(e) => setVagaId(parseInt(e.target.value))}>
                        <option value={0}>Selecione a vaga</option>
                        {vagas.map(vaga => (
                            <option key={vaga.vagaId} value={vaga.vagaId}>{vaga.vagaId}</option>
                        ))}
                    </select>
                </div>
                

                <button type="submit" id="btn_cadastrar">Alterar</button>
            </form>
        </div>
    )
}

export default CarroAlterar;