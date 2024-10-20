using System.Text.Json.Serialization;

namespace APIestacionamento.Models;

public class Recibo
{

    public int ReciboId { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set;}

    [JsonIgnore]
    public Cliente? Cliente { get; set;}
    public int ClienteId { get; set;}
    public Carro? Carro { get; set; }
    public int CarroId { get; set; }
    
    public void CalcularValor()
    {
        TimeSpan permanencia = DataCriacao - (Carro?.DataChegada ?? DateTime.Now);
        int horas = (int)Math.Ceiling(permanencia.TotalHours);
        ValorTotal = 5 + (horas > 1 ? (horas -1) * 10 : 0);
    }

}