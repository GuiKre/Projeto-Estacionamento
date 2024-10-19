using Microsoft.EntityFrameworkCore;

namespace APIestacionamento.Models;

public class AppDataContext : DbContext
{
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Cliente> Clientes{ get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=estacionamento.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Carro>()
            .HasOne(c => c.vaga)
            .WithMany(v => v.Carros) // Muda de WithOne para WithMany
            .HasForeignKey(c => c.VagaId);

        modelBuilder.Entity<Carro>()
            .HasOne(c => c.Cliente)
            .WithMany(cliente => cliente.Carros)
            .HasForeignKey(c => c.ClienteId);
    }
}
