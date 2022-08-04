using CityNews_Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;

namespace CityNews_Persistence.Context {
  public class HistorialContext : DbContext {
    public DbSet<CityEntity> City { get; set; }

    public HistorialContext(DbContextOptions<HistorialContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);
    }
  }
}
