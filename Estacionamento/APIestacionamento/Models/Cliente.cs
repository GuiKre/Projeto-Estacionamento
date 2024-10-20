using System.Text.Json.Serialization;

namespace APIestacionamento.Models;

public class Cliente
{

    public int ClienteId { get; set; }
    public string? Nome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    public int CarroId { get; set;}

    [JsonIgnore]
    public Carro? Carro {get; set; }
    
    //[JsonIgnore] 
    public ICollection<Recibo> Recibos { get; set;} = new List<Recibo>();
}