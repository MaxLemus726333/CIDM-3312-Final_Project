using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    // Needed for Many-to-Many association entity
    // CollectionCard entity has 2 attributes as the primary key.
    // This code tells EF Core that CardID and CollectionID combine for the primary key
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectionCard>().HasKey(s => new {s.CardID, s.CollectionID});
    }

    public DbSet<Collection> Collections {get; set;}
    public DbSet<Card> Cards {get; set;}
    public DbSet<CollectionCard> CollectionCards {get; set;}
    // public DbSet<Gen> Gens {get; set;}
}