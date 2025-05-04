namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Data.DbConfiguration;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        builder.HasKey(s => s.Id)
            .HasName("shipments_pkey");

        builder.ToTable("shipments");

        builder.Property(s => s.Id)
            .HasColumnName("id");

        builder.Property(s => s.CreatedBy)
            .HasMaxLength(50)
            .HasColumnName("createdBy");

        builder.Property(s => s.CreatedDate)
            .HasColumnType("timestamp")
            .HasColumnName("createdDate");

        builder.Property(s => s.LastModificateBy)
            .HasMaxLength(50)
            .HasColumnName("lastModificatedBy");

        builder.Property(s => s.LastModificateDate)
            .HasColumnType("timestamp")
            .HasColumnName("lastModificateDate");

        builder.Property(s => s.TrackingNumber)
           .IsRequired()
           .HasMaxLength(50)
           .HasColumnName("tracking_number");

        builder.Property(s => s.Transporter)
           .IsRequired()
           .HasMaxLength(50)
           .HasColumnName("transporter");

        builder.Property(s => s.DeliveryDate)
            .HasColumnType("timestamp")
            .IsRequired()
            .HasColumnName("delivery_date");

        builder.Property(s => s.ShipmentStatus)
           .IsRequired()
           .HasConversion<string>()
           .HasMaxLength(20)
           .HasDefaultValue(ShipmentStatus.Preparing)
           .HasColumnName("shipment_status");

        builder.HasIndex(s => s.TrackingNumber).IsUnique();
        builder.HasIndex(s => s.ShipmentStatus);
        builder.HasIndex(s => s.CreatedDate);

        builder.HasOne(s => s.WareHouse)
           .WithMany(w => w.Shipments)
           .HasForeignKey(s => s.WareHouseId)
           .HasConstraintName("fk_shipments_warehouses");

    }
}

