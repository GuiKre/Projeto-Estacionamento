using System;

namespace APIestacionamento.Models;

public class Recibo
{
    public int ReciboId { get; set; }
    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public int CarroId { get; set; }
    public Carro? Carro { get; set; }
    public int VagaId { get; set; }
    public Vaga? Vaga { get; set; }
    public DateTime DataChegada { get; set; }
    public DateTime HoraSaida { get; set; }
    public decimal ValorTotal { get; set; }

    public decimal ValorHora { get; set; }
}
