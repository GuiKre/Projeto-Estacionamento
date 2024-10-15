using Microsoft.EntityFrameworkCore;

namespace APIestacionamento.Models;

public class AppDataContext : DbContext
{
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Vaga> Vagas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=estacionamento.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>()
            .HasOne(c =>c.vaga)
            .WithOne(v => v.carro)
            .HasForeignKey<Carro>(c => c.VagaId);
    }
}
