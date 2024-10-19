using Microsoft.EntityFrameworkCore;

namespace APIestacionamento.Models;

public class AppDataContext : DbContext
{
    public DbSet<Carro> Carros { get; set; }
    public DbSet<Vaga> Vagas { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Recibo> Recibos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=estacionamento.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carro>()
            .HasOne(c => c.Vaga)
            .WithMany(v => v.Carros)
            .HasForeignKey(c => c.VagaId);

        modelBuilder.Entity<Carro>()
            .HasOne(c => c.Cliente)
            .WithMany(cliente => cliente.Carros)
            .HasForeignKey(c => c.ClienteId);
        
        modelBuilder.Entity<Cliente>()
            .Property(c => c.ClienteId)
            .ValueGeneratedOnAdd(); 

        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Cliente)
            .WithMany(c => c.Recibos)
            .HasForeignKey(r => r.ClienteId);

        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Carro)
            .WithMany(c => c.Recibos)
            .HasForeignKey(r => r.CarroId);

        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Vaga)
            .WithMany(v => v.Recibos)
            .HasForeignKey(r => r.VagaId);
    }
}
