namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Data.DbConfiguration;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.HasKey(i => i.Id)
             .HasName("inventories_pkey");

        builder.ToTable("inventories");

        builder.Property(i => i.Id)
            .HasColumnName("id");

        builder.Property(i => i.CreatedBy)
            .HasMaxLength(50)
            .HasColumnName("createdBy");

        builder.Property(i => i.CreatedDate)
            .HasColumnType("timestamp")
            .HasColumnName("createdDate");

        builder.Property(i => i.LastModificateBy)
            .HasMaxLength(50)
            .HasColumnName("lastModificatedBy");

        builder.Property(i => i.LastModificateDate)
            .HasColumnType("timestamp")
            .HasColumnName("lastModificateDate");

        builder.Property(i => i.Quantity)
            .IsRequired()
            .HasDefaultValue(0)
            .HasColumnName("quantity");

        builder.Property(i => i.BatchNumber)
            .HasMaxLength(50)
            .HasColumnName("batchNumber");

        builder.Property(i => i.BestbeforeDate)
            .IsRequired()
            .HasColumnType("timestamp")
            .HasColumnName("bestbeforeDate");

        builder.HasIndex(i => i.BestbeforeDate);

        builder.HasOne(i => i.Product)
            .WithMany(p => p.InventoryHistory)
            .HasForeignKey(i => i.ProductId)
            .HasConstraintName("fk_product_inventoryhisory");

        builder.HasOne(i => i.WareHouse)
            .WithMany(p => p.Inventories)
            .HasForeignKey(i => i.WareHouseId)
            .HasConstraintName("fk_warehouse_inventory");
    }
}


