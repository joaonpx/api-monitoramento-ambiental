using Microsoft.EntityFrameworkCore;
using Api.Monitoramento.Ambiental.Models;

namespace Api.Monitoramento.Ambiental.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Desastre> Desastres { get; set; }
    public DbSet<Irrigacao> Irrigacoes { get; set; }
    public DbSet<Qualidade> Qualidades { get; set; }
    
  }
}