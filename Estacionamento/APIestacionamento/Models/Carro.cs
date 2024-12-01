using System.Text.Json.Serialization;

namespace APIestacionamento.Models;

public class Carro
{
    public int CarroId { get; set; }
    public string? Placa { get; set; }
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public string? Cor { get; set; }
    public DateTime DataChegada { get; set; } = DateTime.Now;

    [JsonIgnore]
    public int VagaId { get; set; }
    public Vaga? vaga { get; set; }

    [JsonIgnore]
    public Cliente? cliente { get; set; }

}
