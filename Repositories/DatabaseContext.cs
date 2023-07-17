using Microsoft.EntityFrameworkCore;
using Teste.Domain;

namespace Teste.Repositories;
public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions<DatabaseContext> options)
    : base (options) {}
  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
        optionsBuilder.UseSqlite("Data Source=database.db");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
        modelBuilder.Entity<Carro>().ToTable("carro");
        modelBuilder.Entity<User>().ToTable("users");
  }
  public DbSet<Carro> Carro { get; set; }
  public DbSet<User> User { get; set; }
}