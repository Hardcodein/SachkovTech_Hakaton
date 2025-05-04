namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Data.DbConfiguration;

public class ShipmentItemConfiguration : IEntityTypeConfiguration<ShipmentItem>
{
    public void Configure(EntityTypeBuilder<ShipmentItem> builder)
    {
        builder.HasKey(si => si.Id)
           .HasName("shipment_item_pkey");

        builder.ToTable("shipment_items");

        builder.Property(si => si.Id)
            .HasColumnName("id");

        builder.Property(si => si.CreatedBy)
            .HasMaxLength(50)
            .HasColumnName("createdBy");

        builder.Property(si => si.CreatedDate)
            .HasColumnType("timestamp")
            .HasColumnName("createdDate");

        builder.Property(si => si.LastModificateBy)
            .HasMaxLength(50)
            .HasColumnName("lastModificatedBy");

        builder.Property(si => si.LastModificateDate)
            .HasColumnType("timestamp")
            .HasColumnName("lastModificateDate");

        builder.Property(si => si.Quantity)
            .IsRequired()
            .HasColumnName("quantity");

        builder.Property(si => si.BatchNumber)
            .IsRequired()
            .HasColumnName("batch_number");

        builder.HasIndex(si => si.ProductId);

        builder.HasOne(si => si.Shipment)
            .WithMany(s => s.Items)
            .HasForeignKey(si => si.ShipmentId)
            .HasConstraintName("shipment_id");

       
        builder.HasOne(si => si.Product)
            .WithMany(p=>p.Items)
            .HasForeignKey(si => si.ProductId)
            .HasConstraintName("product_id");
    }
}
