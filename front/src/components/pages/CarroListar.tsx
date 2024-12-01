import { useEffect, useState } from "react";
import { Carro } from "../models/Carro";
import axios from "axios";
import { Link } from "react-router-dom";

function CarroListar() {
    const [carros, setCarros] = useState<Carro[]>([]);

    useEffect(() => {
        fetch("http://localhost:5122/api/carros/listar")
            .then(resposta => resposta.json())
            .then(carros => {
                setCarros(carros);
            });
    }, []);

    function deletar(id : number){
        console.log("ID enviado para exclusão:", id);

    if (window.confirm("Tem certeza que deseja deletar este carro?")) {
        axios.delete(`http://localhost:5122/api/carros/deletar/${id}`)
            .then(() => {
                setCarros(carros.filter(carro => carro.carroId !== id));
            })
            .catch(erro => console.error("Erro ao deletar o carro:", erro));
    }
    }

    return (
        <div>
            <h1>Lista de Carros</h1>
            {carros.length > 0 ? (
            <table border={1}>
                <thead>
                    <tr>
                        <th>Placa</th>
                        <th>Marca</th>
                        <th>Modelo</th>
                        <th>Cor</th>
                        <th>Vaga</th>
                        <th>Deletar</th>
                        <th>Alterar</th>
                    </tr>
                </thead>
                <tbody>
                    {carros.map(carro => (
                        <tr key={carro.carroId}>
                            <td>{carro.placa}</td>
                            <td>{carro.marca}</td>
                            <td>{carro.modelo}</td>
                            <td>{carro.cor}</td>
                            <td>{carro.vaga?.vagaId}</td>
                            <td><button onClick={() => deletar(carro.carroId!)}>Deletar</button></td>
                            <td><Link to={`/pages/carros/alterar/${carro.carroId}`}>Alterar Carro</Link></td>
                        </tr>
                    ))}
                </tbody>
            </table>
            ) : (
                <p>Não há carros cadastrados.</p>
            )}
        </div>
    );
}

export default CarroListar;
