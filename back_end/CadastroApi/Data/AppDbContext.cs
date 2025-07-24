using Microsoft.EntityFrameworkCore;
using CadastroApi.Models;

namespace CadastroApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Regiao> Regioes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔹 Índice único para UF + Nome
            modelBuilder.Entity<Regiao>()
                .HasIndex(r => new { r.Uf, r.Nome })
                .IsUnique();
        }
    }
}
