using Microsoft.EntityFrameworkCore;
using ProcessoDigital.Data.Model;

namespace ProcessoDigital.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Processo> Processos { get; set; }
        public DbSet<Andamento> Andamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de relacionamento Cliente -> Processos
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.Processos)
                .WithOne(p => p.Cliente)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Restrict); // Evita deletar Cliente se tiver processos ativos (Segurança)

            // Configuração de relacionamento Processo -> Andamentos
            modelBuilder.Entity<Processo>()
                .HasMany(p => p.Andamentos)
                .WithOne(a => a.Processo)
                .HasForeignKey(a => a.ProcessoId)
                .OnDelete(DeleteBehavior.Cascade); // Deletou processo, somem os andamentos
        }
    }
}