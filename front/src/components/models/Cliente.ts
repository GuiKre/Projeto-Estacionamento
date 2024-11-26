import { Carro } from "./Carro";

export interface Cliente{
    clienteId?: number;
    nome: string;
    telefone: string;
    email: string;
    carroId: number;
    carro?: Carro;
}