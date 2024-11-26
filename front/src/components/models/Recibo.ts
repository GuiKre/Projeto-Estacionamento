import { Cliente } from "./Cliente";
import { Carro } from "./Carro";

export interface Recibo{
    reciboId: number;
    dataCriacao?: string;
    valorTotal: number;
    cliente?: Cliente;
    clienteId: number;
    carroId: number;
    carro?: Carro;
}