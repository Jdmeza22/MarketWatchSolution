
using MarketWatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketWatch.Persistence;

public class MarketWatchDbContext : DbContext
{
    public MarketWatchDbContext(DbContextOptions<MarketWatchDbContext> options) : base(options) { }

    public DbSet<Symbol> Symbols => Set<Symbol>();

    /// <summary>
    /// Method to configure the model for the database.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Symbol>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });
    }

}
