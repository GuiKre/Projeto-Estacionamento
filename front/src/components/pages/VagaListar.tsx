import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Vaga } from "../models/Vaga";

function VagaListar(){
    const [vagas, setVagas] = useState<Vaga[]>([]);

    useEffect(() => {
        fetch("http://localhost:5122/api/vagas/listar")
            .then(resposta => {
                return resposta.json();
            })
            .then(vagas => {
                setVagas(vagas);
            })
    })

    return(
        <div className="div-lista">
        <h1>Vagas Lista!</h1>

        <table border={1}>
                <thead>
                    <tr>
                        <th>Vaga Id</th>
                        <th>Número</th>
                    </tr>
                </thead>
                <tbody>
                    {vagas.map(vaga => (
                        <tr key={vaga.vagaId}>
                            <td>{vaga.vagaId}</td>
                            <td>{vaga.numero}</td>
                        </tr>
                    ))}
                </tbody>
        </table>

    </div>
    );
}

export default VagaListar;