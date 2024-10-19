namespace APIestacionamento.Models;

public class Cliente
{
    public int ClienteId { get; set; }
    public string? Nome { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }

    public List<Carro> Carros { get; set; } = new();
    public List<Recibo> Recibos { get; set; } = new();
}
