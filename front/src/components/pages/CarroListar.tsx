import { useEffect, useState } from "react";
import { Carro } from "../models/Carro";

function CarroListar() {
    const [carros, setCarros] = useState<Carro[]>([]);

    useEffect(() => {
        fetch("http://localhost:5122/api/carros/listar")
            .then(resposta => resposta.json())
            .then(carros => {
                setCarros(carros);
            });
    }, []);

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
                    </tr>
                </thead>
                <tbody>
                    {carros.map(carro => (
                        <tr key={carro.carroId}>
                            <td>{carro.placa}</td>
                            <td>{carro.marca}</td>
                            <td>{carro.modelo}</td>
                            <td>{carro.cor}</td>
                            <td>{carro.vaga?.numero}</td>
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
