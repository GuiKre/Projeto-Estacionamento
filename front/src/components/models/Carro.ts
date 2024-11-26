import { Vaga } from "./Vaga";
import { Cliente } from "./Cliente";

export interface Carro{
    carroId?: number;
    placa: string;
    marca: string;
    modelo: string;
    cor: string;
    dataChegada?: string;
    vagaId: number;
    vaga?: Vaga;
    cliente?: Cliente;
}