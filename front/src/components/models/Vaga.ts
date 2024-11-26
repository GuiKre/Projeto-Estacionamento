import { Carro } from "./Carro";

export interface Vaga{
    vagaId: number;
    numero: string;
    carro?: Carro;
}