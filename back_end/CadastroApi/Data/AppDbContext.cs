using Microsoft.EntityFrameworkCore;
using CadastroApi.Models;

namespace CadastroApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Regiao> Regioes { get; set; }
    }
}
