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
            .HasOne(c =>c.vaga)
            .WithOne(v => v.carro)
            .HasForeignKey<Carro>(c => c.VagaId);

        modelBuilder.Entity<Cliente>()
            .HasOne(cl => cl.Carro)
            .WithOne(c => c.cliente)
            .HasForeignKey<Cliente>(cl => cl.CarroId);

        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Cliente)
            .WithMany(c => c.Recibos)
            .HasForeignKey(r => r.ClienteId);

        modelBuilder.Entity<Recibo>()
            .HasOne(r => r.Carro)
            .WithMany()
            .HasForeignKey(r => r.CarroId);
    }
}