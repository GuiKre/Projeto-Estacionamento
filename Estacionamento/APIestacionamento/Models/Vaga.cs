using System.Text.Json.Serialization;

namespace APIestacionamento.Models;

public class Vaga
{
    public int VagaId {get; set; }
    public string? Numero {get; set; }


    [JsonIgnore]
    public Carro? carro {get; set; }
    public List<Carro> Carros { get; set; } = new();
}
