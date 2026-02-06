using Microsoft.EntityFrameworkCore;
using PerformerIdentifier.Core.Entities;

namespace PerformerIdentifier.Core.Data;

/// <summary>
/// Entity Framework Core database context for performer data.
/// </summary>
public class PerformerDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of <see cref="PerformerDbContext"/>.
    /// </summary>
    /// <param name="options">Database context options.</param>
    public PerformerDbContext(DbContextOptions<PerformerDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Gets or sets the performers table.
    /// </summary>
    public DbSet<Performer> Performers => Set<Performer>();

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Performer>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(256);
            entity.Property(e => e.Embedding).IsRequired();
        });
    }
}
