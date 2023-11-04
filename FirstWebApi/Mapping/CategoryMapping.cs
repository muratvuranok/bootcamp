using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootCamp.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories"); // Aksi belirtimdiği sürece DbSet ismi geçerli olacaktır. Categories
        builder.Property(x => x.Name)
        .HasMaxLength(150)
        .IsRequired();  // default değeri true

        builder.Property(x => x.Description)
        .HasMaxLength(500)
        .IsRequired(false);
    }
}


public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(x => x.Name).HasColumnName("UrunAdi").HasMaxLength(100).IsRequired();
        builder.Property(x => x.UnitsInStock).HasColumnName("StokAdet").IsRequired();
        builder.Property(x => x.UnitPrice).HasColumnName("Fiyat").HasPrecision(18, 2);

        builder.Property(x => x.CategoryId).HasColumnName("KategoriId");


        builder.HasOne(x => x.Category)
            .WithMany(x => x.Products)
            .HasForeignKey(x => x.CategoryId);
    }
}