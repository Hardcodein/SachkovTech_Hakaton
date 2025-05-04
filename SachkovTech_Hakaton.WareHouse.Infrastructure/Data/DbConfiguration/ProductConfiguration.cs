namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Data.DbConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id)
            .HasName("products_pkey");

        builder.ToTable("products");

        builder.Property(p => p.Id)
            .HasColumnName("id");

        builder.Property(p => p.CreatedBy)
            .HasMaxLength(50)
            .HasColumnName("createdBy");

        builder.Property(p => p.CreatedDate)
            .HasColumnType("timestamp")
            .HasColumnName("createdDate");

        builder.Property(p => p.LastModificateBy)
            .HasMaxLength(50)
            .HasColumnName("lastModificatedBy");

        builder.Property(p => p.LastModificateDate)
            .HasColumnType("timestamp")
            .HasColumnName("lastModificateDate");

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(p => p.Desckription)
            .HasColumnName("deskription");

        builder.Property(p => p.BarCode)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("barcode");

        builder.Property(p => p.Price)
            .HasColumnType("decimal")
            .HasColumnName("price");

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true)
            .HasColumnName("isActive");

        builder.HasIndex(p => p.Name);

        builder.HasIndex(p => p.BarCode)
            .IsUnique();

        builder.HasMany(p => p.WareHouses)
           .WithMany(w => w.Products)
           .UsingEntity<Inventory>();
    }
}
