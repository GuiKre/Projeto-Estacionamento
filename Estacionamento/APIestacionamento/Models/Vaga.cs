using System.Text.Json.Serialization;

namespace APIestacionamento.Models;

public class Vaga
{
    public int VagaId {get; set; }
    public string? Numero {get; set; }
    public Carro? carro {get; set; }
}