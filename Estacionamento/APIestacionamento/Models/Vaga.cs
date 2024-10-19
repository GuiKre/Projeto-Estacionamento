using System.Text.Json.Serialization;

namespace APIestacionamento.Models;

public class Vaga
{
    public int VagaId {get; set; }
    public string? Numero {get; set; }


    [JsonIgnore]
    public List<Carro> Carros { get; set; } = new List<Carro>();
    public List<Recibo> Recibos { get; set; } = new List<Recibo>();
}
