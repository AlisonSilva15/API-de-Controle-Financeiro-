using FinancasApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancasApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options){}

        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Movimentacao>Movimentacoes {get; set;}
    }
}