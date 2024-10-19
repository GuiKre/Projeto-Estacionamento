using System.Text.Json.Serialization;

namespace APIestacionamento.Models;

public class Carro
{
    public int CarroId {get; set; }
    public string? Placa {get; set; }
    public string? Marca {get; set; }
    public string? Modelo {get; set; }
    public string? Cor {get; set; }
    public DateTime DataChegada {get; set; } = DateTime.Now;

    public int ClienteId { get; set; }
    public Cliente? Cliente { get; set; }
    public List<Recibo> Recibos { get; set; } = new List<Recibo>();

    [JsonIgnore]
    public Vaga? Vaga {get; set; }
    public int VagaId {get; set; }
}
