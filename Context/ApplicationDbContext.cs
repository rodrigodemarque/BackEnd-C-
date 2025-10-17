using APITeste.Model;
using Microsoft.EntityFrameworkCore;

namespace APITeste.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        
        public DbSet<Pessoa> Pessoas{ get; set; }
    }
}