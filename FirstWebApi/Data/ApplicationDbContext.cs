using BootCamp.FirstWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCamp.FirstWebApi.Data;
public class ApplicationDbContext : DbContext  // IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        // fluentapi -> mapping

        modelBuilder.Entity<Category>().ToTable("Categories"); // Aksi belirtimdiği sürece DbSet ismi geçerli olacaktır. Categories
        modelBuilder.Entity<Category>()
        .Property(x => x.Name)
        .HasMaxLength(150)
        .IsRequired();  // default değeri true

        modelBuilder.Entity<Category>()
        .Property(x => x.Description)
        .HasMaxLength(500)
        .IsRequired(false);


        base.OnModelCreating(modelBuilder);
    }
}