using BootCamp.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BootCamp.FirstWebApi.Data;
public class ApplicationDbContext : DbContext  // IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Shipper> Shippers { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // fluentapi -> mapping




        modelBuilder.Entity<Shipper>().ToTable("Shippers");
        modelBuilder.Entity<Shipper>()
        .Property(x => x.CompanyName)
        .HasMaxLength(150)
        .IsRequired();

        modelBuilder.Entity<Shipper>()
        .Property(x => x.Phone)
        .HasMaxLength(24)
        .IsRequired(false);



        modelBuilder.ApplyConfiguration(new CustomerMapping());
        modelBuilder.ApplyConfiguration(new CategoryMapping());
        modelBuilder.ApplyConfiguration(new ProductMapping());

        base.OnModelCreating(modelBuilder);
    }
}