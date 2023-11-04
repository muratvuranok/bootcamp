using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BootCamp.Mapping;

public class CustomerMapping : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers"); //Default değeri  çoğul olarak class'ın adını alır.
        // Musteri  -> Musteries
        // Kategori -> Kategories

        builder.Property<Guid>("Id").HasColumnName("Id");
        builder.Property(p => p.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(100)
            .IsRequired(true);  // boş bırakırsanız default değeri true olarak işaretlidir.

        builder.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired(true);
        builder.Property(p => p.Mail).HasColumnName("Mail").HasMaxLength(100).IsRequired(false);
        builder.Property(p => p.Phone).HasColumnName("Phone").HasMaxLength(25).IsRequired(false);
    }
}
