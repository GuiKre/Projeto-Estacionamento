import { useEffect, useState } from "react";
import { Vaga } from "../models/Vaga";
import axios from "axios";

function VagaCadastrar(){
    const [vagas, setVagas] = useState<Vaga[]>([]);
    const [vagaId, setVagaId] = useState(0);
    const [numero, setNumero] = useState<string>('');

    useEffect(() => {
        axios.get<Vaga[]>("http://localhost:5122/api/vagas/listar")
            .then((resposta) => {
                setVagas(resposta.data);
            })
    })

    function enviarVaga(e : any){
        e.preventDefault();

        const vaga : Vaga = {
            vagaId: vagaId,
            numero: numero,
        }

        fetch("http://localhost:5122/api/vagas/cadastrar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(vaga)
            })
            .then(resposta => {
                return resposta.json();
            })
            .then(vaga => {
                console.log("Vaga cadastrada!", vaga)
            })

    }

    return (
        <div id="cadastrar_vaga">
            <h1>Vaga Cadastrar</h1>

            <form onSubmit={enviarVaga}>
                <div className="divs">
                    <label htmlFor="vagaId">Vaga ID:</label>
                    <input type="number" id="vagaId" name="vagaId" onChange={(e : any) => setVagaId(parseInt(e.target.value))}  />
                </div>
                
                <div className="divs">
                    <label htmlFor="numero">Número:</label>
                    <input type="text" id="numero" name="numero" onChange={(e : any) => setNumero(e.target.value)}  />
                </div>

                <button type="submit" id="btn_cadastrar">Cadastrar</button>
            </form>
        </div>
    );
}

export default VagaCadastrar;