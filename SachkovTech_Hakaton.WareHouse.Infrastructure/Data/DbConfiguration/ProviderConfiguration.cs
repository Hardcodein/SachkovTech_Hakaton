namespace SachkovTech_Hakaton.WareHouse.Infrastructure.Data.DbConfiguration;

public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
{
    public void Configure(EntityTypeBuilder<Provider> builder)
    {
        builder.HasKey(p => p.Id)
            .HasName("providers_pkey");

        builder.ToTable("providers");

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
            .HasMaxLength(100);

        builder.Property(p => p.Member)
            .HasMaxLength(100);

        builder.Property(p => p.Phone)
            .HasMaxLength(20);

    }
}

