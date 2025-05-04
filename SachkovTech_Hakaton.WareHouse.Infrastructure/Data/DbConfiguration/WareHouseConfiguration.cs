namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Data.DbConfiguration;

public class WareHouseConfiguration : IEntityTypeConfiguration<Domain.Models.Entities.WareHouse>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Entities.WareHouse> builder)
    {
        builder.HasKey(a => a   .Id)
           .HasName("warehouse_pkey");

        builder.ToTable("warehouses");

        builder.Property(w => w.Id)
            .HasColumnName("id");

        builder.Property(w => w.CreatedBy)
            .HasMaxLength(50)
            .HasColumnName("createdBy");

        builder.Property(w => w.CreatedDate)
            .HasColumnType("timestamp")
            .HasColumnName("createdDate");

        builder.Property(w => w.LastModificateBy)
            .HasMaxLength(50)
            .HasColumnName("lastModificatedBy");

        builder.Property(w => w.LastModificateDate)
            .HasColumnType("timestamp")
            .HasColumnName("lastModificateDate");

        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(w => w.UniqueCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(w => w.Address)
            .HasColumnName("address");

        builder.Property(w => w.Capacity)
            .HasColumnType("decimal(10,2)");

        builder.Property(w => w.Occupancy)
            .HasColumnType("decimal(10,2)");

        builder.Property(w => w.IsActive)
            .HasDefaultValue(true);

        builder.HasIndex(w => w.UniqueCode).IsUnique();

    }
}
