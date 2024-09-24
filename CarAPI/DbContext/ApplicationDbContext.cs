using CarAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }

    public DbSet<Inquiry> Inquiries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Car timestamps
        modelBuilder.Entity<Car>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Car>()
            .Property(c => c.UpdatedAt)
            .HasDefaultValueSql("GETDATE()");

        // Car datatype
        modelBuilder.Entity<Car>()
            .Property(c => c.Price)
            .HasPrecision(18, 2);

        // Inquiry timestamps
        modelBuilder.Entity<Inquiry>()
            .Property(i => i.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Inquiry>()
            .Property(i => i.UpdatedAt)
            .HasDefaultValueSql("GETDATE()");
    }
}
