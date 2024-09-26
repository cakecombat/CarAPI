using CarAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<CarModel> Cars { get; set; }
    public DbSet<InquiryModel> Inquiries { get; set; }
    public DbSet<CarRequestModel> CarRequests { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Car timestamps
        modelBuilder.Entity<CarModel>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<CarModel>()
            .Property(c => c.UpdatedAt)
            .HasDefaultValueSql("GETDATE()");

        // Car datatype
        modelBuilder.Entity<CarModel>()
            .Property(c => c.Price)
            .HasPrecision(18, 2);

        // Inquiry timestamps
        modelBuilder.Entity<InquiryModel>()
            .Property(i => i.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<InquiryModel>()
            .Property(i => i.UpdatedAt)
            .HasDefaultValueSql("GETDATE()");
    }
}
