using Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace Persistence {
  public class CityNewsDbContext : DbContext {
    public DbSet<City> City { get; set; }

    public CityNewsDbContext(DbContextOptions<CityNewsDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
    }
  }
}
